using AMSS.Models;
using AMSS.Models.Dto.Auth;

namespace AMSS.Services.IService
{
    public interface IAuthService 
    {
        Task<APIResponse<LoginResponseDto>> LoginAsync(string username, string password);
        Task<APIResponse<bool>> RegisterAsync(RegistrationRequestDto registrationDto);
        Task<APIResponse<string>> RefreshTokenAsync(string refreshToken, string accessToken);
    }
}
