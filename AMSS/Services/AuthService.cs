using AMSS.Constants;
using AMSS.Dto.Auth;
using AMSS.Dto.Requests.Mails;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Entities.Locations;
using AMSS.Enums;
using AMSS.Infrastructures.Configurations;
using AMSS.Models.Suppliers;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Services.IService.BackgroundJob;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
        private readonly IBackgroundJobClient _backgroundJob;
        private readonly SupplierConfiguration _supplierConfiguration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenService, IBackgroundJobClient backgroundJob, IOptionsMonitor<SupplierConfiguration> supplierConfiguration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            _backgroundJob = backgroundJob;
            _supplierConfiguration = supplierConfiguration.CurrentValue;
        }

        public async Task<APIResponse<LoginResponseDto>> LoginAsync(string username, string password)
        {
            ApplicationUser user = await _unitOfWork.UserRepository.GetAsync(u => u.UserName!.ToLower() == username.ToLower() && !u.IsDeleted);
            if (user == null)
            {
                return BuildErrorResponseMessage<LoginResponseDto>("Username does not exist", HttpStatusCode.Unauthorized);
            }
            if (!user.IsActive)
            {
                return BuildErrorResponseMessage<LoginResponseDto>("This account has been locked", HttpStatusCode.Forbidden);
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

        public async Task<APIResponse<bool>> RegisterAsync(RegistrationRequestDto registrationDto)
        {
            ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.UserName.ToLower() == registrationDto.UserName.ToLower() && !u.IsDeleted);

            if (userFromDb != null)
            {
                return BuildErrorResponseMessage<bool>("Username already exists", HttpStatusCode.Conflict);
            }

            // Find Country and Province name
            var countryWithRequest = await _unitOfWork.CountryContinentRepository.FirstOrDefaultAsync(u => u.CountryCode.Equals(registrationDto.Country));
            string provinceName = null;
            if (!string.IsNullOrEmpty(registrationDto.ProvinceCode))
            {
                var provinceSupplier = await _unitOfWork.ProvinceRepository.FirstOrDefaultAsync(u => u.Code.Equals(registrationDto.ProvinceCode));
                provinceName = provinceSupplier.Name;
            }

            // Create new user
            ApplicationUser newUser = new()
            {
                UserName = registrationDto.UserName.Trim(),
                Email = registrationDto.UserName.Trim(),
                NormalizedEmail = registrationDto.UserName.ToUpper().Trim(),
                Password = !string.IsNullOrEmpty(registrationDto.Password) ? BCrypt.Net.BCrypt.HashPassword(registrationDto.Password)
                                                            : BCrypt.Net.BCrypt.HashPassword(_supplierConfiguration.DefaultPassword),
                FullName = registrationDto.ContactName.Trim(),
                Avatar = registrationDto.Avatar,
                StreetAddress = registrationDto.StreetAddress?.Trim() ?? null,
                CountryCode = registrationDto.Country,
                CountryName = countryWithRequest.CountryName,
                PhoneCode = registrationDto.PhoneCode,
                PhoneNumber = registrationDto.PhoneNumber,
                ProvinceName = !string.IsNullOrEmpty(provinceName) ? provinceName : null,
                ProvinceCode = registrationDto.ProvinceCode ?? null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(newUser);

            if (!result.Succeeded)
            {
                return BuildErrorResponseMessage<bool>(result.Errors.FirstOrDefault()?.Description!, HttpStatusCode.Forbidden);
            }

            // Create new role if not exist, 
            string userRole = registrationDto.Role.GetDisplayName();
            if (!_roleManager.RoleExistsAsync(userRole).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(userRole));
            }
            await _userManager.AddToRoleAsync(newUser, userRole);

            // if user is supplier, create new supplier
            if (registrationDto.Role is not Role.ADMIN && registrationDto.Role is not Role.CUSTOMER)
            {
                // Create new location 
                Location userLocation = new(registrationDto, Guid.Parse(newUser.Id));
                await _unitOfWork.LocationRepository.CreateAsync(userLocation);

                Supplier newSupplier = new(registrationDto);
                newSupplier.CountryName = countryWithRequest.CountryName;
                newSupplier.ProvinceName = provinceName;
                await _unitOfWork.SupplierRepository.CreateAsync(newSupplier);
            }

            await _unitOfWork.SaveChangeAsync();

            // Send mail registration successfully
            var mailRequest = new MailRequest
            {
                Tos = [new() { Name = registrationDto.ContactName, Email = registrationDto.UserName }],
                Ccs = [new() { Email = "admin@fuco.com" }],
                IsHtml = true,
                Subject = "You're Invited to Join Novaris – Let's Get Started!",
                TemplateName = "RegisterClientTemplate"
            };
            _backgroundJob.Enqueue<ISendEmailJob>(QueueName.SendEmailJob, job => job.InvokeAsync(mailRequest));

            return BuildSuccessResponseMessage(true, "Registration new account successfully");
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
