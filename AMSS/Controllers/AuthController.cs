using AMSS.Data;
using AMSS.Models.Dto.Auth;
using AMSS.Models.Dto.User;
using AMSS.Models;
using AMSS.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Net.Http.Headers;
using AMSS.Services.IService;
using AMSS.Enums;
using Microsoft.OpenApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AMSS.Repositories.IRepository;

namespace AMSS.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private APIResponse _response;


        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            _response = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                ApplicationUser user = await _unitOfWork.UserRepository.GetAsync(u => u.UserName!.ToLower() == loginRequestDto.UserName.ToLower() && !u.IsDeleted);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("Username does not exist");
                    return Unauthorized(_response);
                }
                if(!user.IsActive)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("This account has been locked");
                    return Unauthorized(_response);
                }
                var isValid = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.Password);
                if (!isValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("Password was incorrect");
                    return Unauthorized(_response);
                }


                // if user was found, generate JWT Token
                var roles = await _userManager.GetRolesAsync(user);
                var accessToken = _jwtTokenService.GenerateToken(user, roles);
                var refreshToken = _jwtTokenService.GenerateRefreshToken();

                var token = new TokenDto()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };

                await _unitOfWork.UserRepository.UpdateRefreshToken(user.Id, refreshToken);

                var userDto = _mapper.Map<UserDto>(user);
                userDto.Role = Enum.Parse<Role>(roles.FirstOrDefault()!);

                LoginResponseDto loginResponseDto = new()
                {
                    User = userDto,
                    Token = token,
                };
                _response.SuccessMessage = "Welcome " + userDto.FullName + "! Have a nice day🌟";
                _response.Result = loginResponseDto;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationDto)
        {
            if (registrationDto.UserName == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.UserName!.ToLower() == registrationDto.UserName.ToLower() && !u.IsDeleted);

            if (userFromDb != null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
            ApplicationUser newUser = new()
            {
                UserName = registrationDto.UserName,
                Email = registrationDto.UserName,
                NormalizedEmail = registrationDto.UserName.ToUpper(),
                Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password),
                FullName = registrationDto.FullName,
                Avatar = registrationDto.Avatar,
                PhoneNumber = registrationDto.PhoneNumber,
                StreetAddress = registrationDto.StreetAddress,
                City = registrationDto.City,
                State = registrationDto.State,
                Country = registrationDto.Country,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser);
                string userRole = registrationDto.Role.GetDisplayName();
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(userRole).GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole(userRole));
                    }
                    //if(!String.IsNullOrEmpty(userRole))
                    //{
                    //    if (userRole.ToLower() == Role.ADMIN.ToString())
                    //    {
                    //        await _userManager.AddToRoleAsync(newUser, Role.ADMIN.ToString());
                    //    }
                    //    else if (userRole.ToLower() == Role.OWNER.ToString())
                    //    {
                    //        await _userManager.AddToRoleAsync(newUser, Role.OWNER.ToString());
                    //    }
                    //}
                    //else
                    //{
                    //    await _userManager.AddToRoleAsync(newUser, Role.FARMER.ToString());
                    //}
                    await _userManager.AddToRoleAsync(newUser, userRole);
                }
                else
                {
                    throw new Exception(result.Errors.FirstOrDefault()?.Description);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.SuccessMessage = "Registration new account successfully";
                _response.Result = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto tokenRequestDto)
        {
            try
            {
                var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(tokenRequestDto.RefreshToken))
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Unaccepted token");
                    return BadRequest(_response);
                }

                if(string.IsNullOrEmpty(accessToken))
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Unauthorized");
                    return BadRequest(_response);
                }

                var principal = _jwtTokenService.GetPrincipalFromExpiredToken(accessToken);
                if(principal == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("Unauthorized");
                    return Unauthorized(_response);
                }
                var userEmail = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = await _unitOfWork.UserRepository.GetAsync(u => u.UserName == userEmail && !u.IsDeleted);
                if(user.RefreshToken != tokenRequestDto.RefreshToken || !_jwtTokenService.ValidateTokenExpire(tokenRequestDto.RefreshToken))
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("Unauthorized");
                    return Unauthorized(_response);
                }

                var roles = await _userManager.GetRolesAsync(user);
                var newAccessToken = _jwtTokenService.GenerateToken(user, roles);
                if(string.IsNullOrEmpty(newAccessToken))
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessages.Add("Unauthorized");
                    return Unauthorized(_response);
                }

                var tempRoles = await _userManager.GetRolesAsync(user);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = newAccessToken;
                _response.SuccessMessage = "Refresh token successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            return Ok(_response);
        }
    }
}
