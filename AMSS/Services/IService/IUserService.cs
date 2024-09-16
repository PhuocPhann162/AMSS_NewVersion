using AMSS.Models;
using AMSS.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IUserService
    {
        Task<APIResponse<IEnumerable<UserDto>>> GetAllUsersAsync(string? searchString, int pageNumber = 1, int pageSize = 5);
        Task<APIResponse<bool>> LockUnlockAsync(string? id);
        Task<APIResponse<bool>> RoleManagementAsync(string userId, string role);
        Task<APIResponse<bool>> UpdateInfoAsync(string userId, UpdateUserDto updateUserDto);

    }
}
