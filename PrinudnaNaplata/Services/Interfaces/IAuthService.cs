using PrinudnaNaplata.Models.Dto.Auth;
using PrinudnaNaplata.Models.Dtos.Auth;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

        Task<Result<ChangePasswordResponseDto>> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        Task<Result<ResetPasswordResponseDto>> ResetPasswordAsync(string userId, string newPassword);
    }
}
