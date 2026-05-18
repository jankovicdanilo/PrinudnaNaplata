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

        public AuthController(IAuthService authService, UserManager<IdentityUser> userManager)
        {
            this.authService = authService;
            this.userManager = userManager;
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
    }
}
