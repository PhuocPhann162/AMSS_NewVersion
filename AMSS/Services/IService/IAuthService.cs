using AMSS.Dto.Auth;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IAuthService 
    {
        Task<APIResponse<LoginResponseDto>> LoginAsync(string username, string password);
        Task<APIResponse<bool>> RegisterAsync(RegistrationRequestDto registrationDto);
        Task<APIResponse<string>> RefreshTokenAsync(string refreshToken, string accessToken);
    }
}
