using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.Auth;
using AMSS.Models.Dto.User;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Extensions;
using System.Net;
using System.Security.Claims;

namespace AMSS.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<APIResponse<LoginResponseDto>> LoginAsync(string username, string password)
        {
            try
            {
                ApplicationUser user = await _unitOfWork.UserRepository.GetAsync(u => u.UserName!.ToLower() == username.ToLower() && !u.IsDeleted);
                if (user == null)
                {
                    return BuildErrorResponseMessage<LoginResponseDto>("Username does not exist", HttpStatusCode.Unauthorized);
                }
                if (!user.IsActive)
                {
                    return BuildErrorResponseMessage<LoginResponseDto>("This account has been locked", HttpStatusCode.Unauthorized);
                }
                var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (!isValid)
                {
                    return BuildErrorResponseMessage<LoginResponseDto>("Password was incorrect", HttpStatusCode.Unauthorized);
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
                return BuildSuccessResponseMessage(loginResponseDto, "Welcome " + userDto.FullName + "! Have a nice day🌟");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<LoginResponseDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> RegisterAsync(RegistrationRequestDto registrationDto)
        {
            ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.UserName!.ToLower() == registrationDto.UserName.ToLower() && !u.IsDeleted);

            if (userFromDb != null)
            {
                return BuildErrorResponseMessage<bool>("Username already exists", HttpStatusCode.Conflict);
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
                    return BuildErrorResponseMessage<bool>(result.Errors.FirstOrDefault()?.Description!, HttpStatusCode.Forbidden);
                }

                return BuildSuccessResponseMessage(true, "Registration new account successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<string>> RefreshTokenAsync(string refreshToken, string accessToken)
        {
            try
            {
                if (string.IsNullOrEmpty(refreshToken))
                {
                    return BuildErrorResponseMessage<string>("Unaccepted token", HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrEmpty(accessToken))
                {
                    return BuildErrorResponseMessage<string>("Access Token must be valid", HttpStatusCode.Unauthorized);
                }

                var principal = _jwtTokenService.GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                {
                    return BuildErrorResponseMessage<string>("Access Token must be valid", HttpStatusCode.Unauthorized);
                }
                var userEmail = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = await _unitOfWork.UserRepository.GetAsync(u => u.UserName == userEmail && !u.IsDeleted);
                if (user.RefreshToken != refreshToken || !_jwtTokenService.ValidateTokenExpire(refreshToken))
                {
                    return BuildErrorResponseMessage<string>("RefreshToken must be valid", HttpStatusCode.Unauthorized);
                }

                var roles = await _userManager.GetRolesAsync(user);
                var newAccessToken = _jwtTokenService.GenerateToken(user, roles);
                if (string.IsNullOrEmpty(newAccessToken))
                {
                    return BuildErrorResponseMessage<string>("Failed to get new access token", HttpStatusCode.BadRequest);
                }

                var tempRoles = await _userManager.GetRolesAsync(user);
                return BuildSuccessResponseMessage(newAccessToken, "Refresh token successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<string>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

    }
}
