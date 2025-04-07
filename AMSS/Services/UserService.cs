using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace AMSS.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<APIResponse<IEnumerable<UserDto>>> GetAllUsersAsync(string? searchString, int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                IEnumerable<ApplicationUser> lstUsers = await _unitOfWork.UserRepository.GetAllAsync(u => !u.IsDeleted);

                foreach (var user in lstUsers)
                {
                    user.Role = Enum.Parse<Role>(_userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()!);
                }

                var lstUserDtos = _mapper.Map<IEnumerable<UserDto>>(lstUsers);

                if (!string.IsNullOrEmpty(searchString))
                {
                    lstUserDtos = lstUserDtos.Where(u => u.FullName.ToLower().Contains(searchString.ToLower()) || u.PhoneNumber.Contains(searchString) || u.Role.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                }

                Pagination pagination = new()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = lstUsers.Count(),
                };
                var paginatedUsers = lstUserDtos.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                return BuildSuccessResponseMessage(paginatedUsers, "Get all Users successfully", pagination: pagination);
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<UserDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
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

        public async Task<APIResponse<bool>> UpdateInfoAsync(string userId, UpdateUserDto updateUserDto)
        {
            try
            {

                if (string.IsNullOrEmpty(userId) || updateUserDto == null)
                {
                    return BuildErrorResponseMessage<bool>("Invalid User ID", HttpStatusCode.BadRequest);
                }
                ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId && !u.IsDeleted, false);
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
    }
}
