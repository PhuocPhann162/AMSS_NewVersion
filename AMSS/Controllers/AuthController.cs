using AMSS.Models.Dto.Auth;
using AMSS.Models;
using Microsoft.AspNetCore.Mvc;
using AMSS.Services.IService;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController<AuthController>
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<LoginResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = await _authService.LoginAsync(loginRequestDto.UserName, loginRequestDto.Password);
            return ProcessResponseMessage(response);
        }

        [HttpPost("register")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationDto)
        {
            var response = await _authService.RegisterAsync(registrationDto);
            return ProcessResponseMessage(response);
        }

        [HttpPost("refreshToken")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto tokenRequestDto)
        {
            var accessToken = AccessToken.ToString().Replace("Bearer ", "");
            var response = await _authService.RefreshTokenAsync(tokenRequestDto.RefreshToken, accessToken);
            return ProcessResponseMessage(response);
        }
    }
}
