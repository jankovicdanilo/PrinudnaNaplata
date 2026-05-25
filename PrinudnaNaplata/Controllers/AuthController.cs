using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Models.Dto.Auth;
using PrinudnaNaplata.Models.Dtos.Auth;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public AuthController(IAuthService authService, UserManager<IdentityUser> userManager, IConfiguration configuration, IEmailService emailService)
        {
            this.authService = authService;
            this.userManager = userManager;
            this.configuration = configuration;
            this.emailService = emailService;
        }

        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return Ok(new { message = "Ako email postoji, link za reset je poslan." });

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Uri.EscapeDataString(token);
            var frontendUrl = configuration["Frontend:BaseUrl"];
            var resetLink = $"{frontendUrl}/reset-password.html?email={dto.Email}&token={encodedToken}";

            try
            {
                await emailService.SendAsync(dto.Email, "Resetovanje lozinke", $"<a href='{resetLink}'>Reset</a>");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

            return Ok(new { message = "Ako email postoji, link za reset je poslan." });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.LoginAsync(request);

            if(result == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(result);
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] PasswordChangeRequestDto request)
        {
            var userId = userManager.GetUserId(User);

            var result = await authService.ChangePasswordAsync(userId, request.CurrentPassword, request.NewPassword);

            if (!result.Success)
            {
                return BadRequest(new {result.Message, result.Errors});
            }

            return Ok(result);
        }

        [HttpPut("resetPassword")]
        //[Authorize(Roles = "Administratori")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequestDto request)
        {
            var result = await authService.ResetPasswordAsync(request.Id, request.NewPassword);

            if (!result.Success)
            {
                return BadRequest(new { result.Message, result.Errors });
            }

            return Ok(result);
        }

        [HttpPut("resetPasswordWithToken")]
        public async Task<IActionResult> ResetPasswordWithTokenAsync([FromBody] ResetPasswordWithTokenDto request)
        {
            var result = await authService.ResetPasswordWithTokenAsync(request.Email, request.Token, request.NewPassword);

            if (!result.Success)
                return BadRequest(new { result.Message, result.Errors });

            return Ok(result);
        }
    }
}
