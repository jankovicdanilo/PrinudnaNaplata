using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using PrinudnaNaplata.Models.Dto.Auth;
using PrinudnaNaplata.Models.Dtos.Auth;
using PrinudnaNaplata.Models.Dtos.OldAspNet;
using PrinudnaNaplata.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Dapper.SqlMapper;

namespace PrinudnaNaplata.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            //Step 1: Try new Identity system first
            var existingUser = await userManager.FindByNameAsync(request.Username);

            if(existingUser != null)
            {
                var passwordValid = await userManager.CheckPasswordAsync(existingUser, request.Password);
                if (!passwordValid)
                {
                    return null;
                }

                return await BuildResponseAsync(existingUser);
            }

            //Step 2: Check old aspnet_Membership
            var legacyUser = await GetLegacyUserAsync(request.Username);
            if(legacyUser == null)
            {
                return null;
            }

            if (legacyUser.IsLockedOut)
            {
                return null;
            }

            if(!legacyUser.IsApproved)
            {
                return null;
            }

            //Step 3: Validate password against old hash
            var passwordMatches = ValidateLegacyPassword(request.Password, legacyUser);
            if (!passwordMatches)
            {
                return null;
            }

            //Step 4: Migrate user to new Identity
            var newUser = new IdentityUser
            {
                UserName = legacyUser.UserName,
                Email = legacyUser.Email,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(newUser, request.Password);
            if (!createResult.Succeeded)
            {
                return null;
            }

            //Step 5: Migrate roles
            var legacyRoles = await GetLegacyRolesAsync(legacyUser.UserId);
            foreach(var role in legacyRoles)
            {
                var roleExists = await userManager.IsInRoleAsync(newUser, role);
                if (!roleExists)
                {
                    await userManager.AddToRoleAsync(newUser, role);
                }
            }

            return await BuildResponseAsync(newUser);
        }

        // ── Private helpers ───────────────────────────────────────────────────────

        private async Task<LegacyUser?> GetLegacyUserAsync(string username)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<LegacyUser>
                (
                    @"SELECT u.UserName, u.UserId, m.Password, m.PasswordFormat,
                             m.PasswordSalt, m.Email, m.IsApproved, m.IsLockedOut
                      FROM aspnet_Users u
                      JOIN aspnet_Membership m ON u.UserId = m.UserId
                      WHERE u.LoweredUserName = @username",
                    new { username = username.ToLower() }
                );
        }

        private async Task<List<string>> GetLegacyRolesAsync(Guid userId)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(connectionString);

            var roles = await connection.QueryAsync<string>
                (
                    @"SELECT r.RoleName
                      FROM aspnet_Roles r
                      JOIN aspnet_UsersInRoles ur on ur.RoleId = r.RoleId
                      WHERE ur.UserId = @userId",
                    new {userId}
                );

            return roles.ToList();
        }

        private static bool ValidateLegacyPassword(string plainPassword, LegacyUser user)
        {
            return user.PasswordFormat switch
            {
                //Plain text
                0 => plainPassword == user.Password,

                //SHA1 hashed with salt
                1 => ValidateSha1Password(plainPassword, user.Password, user.PasswordSalt),

                //SHA256 hashed with salt
                2 => ValidateSha256Password(plainPassword, user.Password, user.PasswordSalt),

                _ => false
            };
        }

        private static bool ValidateSha1Password(string plainPassword, string storedHash, string salt)
        {
            try
            {
                var saltBytes = Convert.FromBase64String(salt);
                var passwordBytes = Encoding.Unicode.GetBytes(plainPassword);

                var combined = new byte[saltBytes.Length + passwordBytes.Length];
                Buffer.BlockCopy(saltBytes, 0, combined, 0, saltBytes.Length);
                Buffer.BlockCopy(passwordBytes, 0, combined, saltBytes.Length, passwordBytes.Length);

                var hashBytes = SHA1.HashData(combined);
                var computedHash = Convert.ToBase64String(hashBytes);

                return computedHash == storedHash;
            }
            catch
            {
                return false;
            }
        }

        private static bool ValidateSha256Password(string plainPassword, string storedHash, string salt)
        {
            try
            {
                var saltBytes = Convert.FromBase64String(salt);
                var passwordBytes = Encoding.Unicode.GetBytes(plainPassword);

                var combined = new byte[saltBytes.Length + passwordBytes.Length];
                Buffer.BlockCopy(saltBytes, 0, combined, 0, saltBytes.Length);
                Buffer.BlockCopy(passwordBytes, 0, combined, saltBytes.Length, passwordBytes.Length);

                var hashBytes = SHA256.HashData(combined);
                var computedHash = Convert.ToBase64String(hashBytes);

                return computedHash == storedHash;
            }
            catch
            {
                return false;
            }

        }

        private async Task<LoginResponseDto> BuildResponseAsync(IdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var token = GenerateJwt(user, roles);

            return new LoginResponseDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email ?? string.Empty,
                Token = token,
                Roles = roles.ToList()
            };
        }

        private string GenerateJwt(IdentityUser user, IList<string> roles)
        {
            var key = configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is not configured.");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName!)
            };

            claims.AddRange(roles.Select(role =>  new Claim(ClaimTypes.Role, role)));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
