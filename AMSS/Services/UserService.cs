using AMSS.Dto.Requests.Users;
using AMSS.Dto.Responses;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Net;
using AMSS.Dto.Responses.Users;
using Microsoft.OpenApi.Extensions;
using AMSS.Entities.Locations;

namespace AMSS.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<APIResponse<PaginationResponse<GetCustomersResponse>>> GetCustomersAsync(GetCustomersRequest request)
        {
            var sortExpressions = new List<SortExpression<ApplicationUser>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<ApplicationUser, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["FullName"] = x => x.FullName
            };

            // Sort
            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<ApplicationUser>(sortField, request.OrderByDirection));
            }

            // Filter and Search
            Expression<Func<ApplicationUser, bool>> filter = x =>
                    (request.CountryCodes == null || !request.CountryCodes.Any() || request.CountryCodes.Contains(x.CountryCode)) &&
                    (string.IsNullOrEmpty(request.Search) || x.FullName.Contains(request.Search) || x.Email.Contains(request.Search));

            var suppliersPaginationResult = await _unitOfWork.UserRepository.GetUsersByRoleAsync(   
                Role.CUSTOMER.GetDisplayName(),
                filter,
                request.CurrentPage,
                request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<GetCustomersResponse>(suppliersPaginationResult.CurrentPage, suppliersPaginationResult.Limit,
                            suppliersPaginationResult.TotalRow, suppliersPaginationResult.TotalPage)
            {
                Collection = suppliersPaginationResult.Data.Select(x => new GetCustomersResponse
                {
                    Id = Guid.Parse(x.Id),
                    FullName = x.FullName, 
                    Email = x.Email,
                    Address = x.StreetAddress, 
                    CountryCode = x.CountryCode, 
                    CountryName = x.CountryName,
                    ProvinceCode = x.ProvinceCode,
                    ProvinceName = x.ProvinceName,
                    PhoneCode = x.PhoneCode, 
                    PhoneNumber = x.PhoneNumber,
                    CreatedAt = x.CreatedAt,
                    IsActive = x.IsActive
                })
            };
            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<bool>> LockUnlockAsync(string? id)
        {
            try
            {
                var userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id && !u.IsDeleted);
                if (userFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("User does not exist", HttpStatusCode.BadRequest);
                }
                if (!userFromDb.IsActive)
                {
                    // user is currently locked and we need to unlock them 
                    userFromDb.IsActive = true;
                    userFromDb.UpdatedAt = DateTime.Now;
                    await _unitOfWork.UserRepository.Update(userFromDb);
                    await _unitOfWork.SaveChangeAsync();
                    return BuildSuccessResponseMessage(true, "Unlock this user successfully");
                }
                else
                {
                    userFromDb.IsActive = false;
                    userFromDb.UpdatedAt = DateTime.Now;
                    await _unitOfWork.UserRepository.Update(userFromDb);
                    await _unitOfWork.SaveChangeAsync();
                    return BuildSuccessResponseMessage(true, "Lock this user successfully");
                }
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> RoleManagementAsync(string userId, string role)
        {
            try
            {
                var oldRole = _userManager.GetRolesAsync(await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId && !u.IsDeleted))
               .GetAwaiter().GetResult().FirstOrDefault();

                ApplicationUser applicationUser = await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId && !u.IsDeleted);
                if (!(role == oldRole))
                {
                    if (oldRole != null)
                    {
                        _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                    }
                    _userManager.AddToRoleAsync(applicationUser, role).GetAwaiter().GetResult();
                }
                applicationUser.UpdatedAt = DateTime.Now;
                return BuildSuccessResponseMessage(true, "Update this user's permission successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> UpdateInfoAsync(Guid userId, UpdateUserDto updateUserDto)
        {
            try
            {
                if (string.IsNullOrEmpty(userId.ToString()) || updateUserDto == null)
                {
                    return BuildErrorResponseMessage<bool>("Invalid User ID", HttpStatusCode.BadRequest);
                }
                ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId.ToString() && !u.IsDeleted, false);
                if (userFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("User does not exist", HttpStatusCode.BadRequest);
                }
                if (!string.IsNullOrEmpty(updateUserDto.FullName))
                {
                    userFromDb.FullName = updateUserDto.FullName;
                }

                if (!string.IsNullOrEmpty(updateUserDto.Email))
                {
                    userFromDb.Email = updateUserDto.Email;
                }

                if (!string.IsNullOrEmpty(updateUserDto.UserName))
                {
                    userFromDb.UserName = updateUserDto.UserName;
                }

                if (!string.IsNullOrEmpty(updateUserDto.PhoneNumber))
                {
                    userFromDb.PhoneNumber = updateUserDto.PhoneNumber;
                }

                userFromDb.UpdatedAt = DateTime.Now;
                await _unitOfWork.UserRepository.Update(userFromDb);
                await _unitOfWork.SaveChangeAsync();

                return BuildSuccessResponseMessage(true, "Update this user information successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> UpdateUserLocationAsync(Guid userId, UpdateUserLocationRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId.ToString());
            if(user is null) 
            {
                return BuildErrorResponseMessage<bool>("User does not exist", HttpStatusCode.NotFound);
            }

            var newLocation = new Location()
            {
                Id = Guid.NewGuid(),
                Address = request.StreetAddress, 
                Lat = request.Lat,
                Lng = request.Lng,
                CountryCode = user.CountryCode,
                City = user.ProvinceName,
                ApplicationUserId = userId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,   
            };

            await _unitOfWork.LocationRepository.AddAsync(newLocation);

            // update user street address 
            user.StreetAddress = request.StreetAddress;

            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true);
        }
    }
}
