using AMSS.Dto.Requests.Users;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Users;
using AMSS.Dto.User;
using AMSS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IUserService
    {
        Task<APIResponse<PaginationResponse<GetCustomersResponse>>> GetCustomersAsync(GetCustomersRequest request);
        Task<APIResponse<bool>> LockUnlockAsync(string? id);
        Task<APIResponse<bool>> RoleManagementAsync(string userId, string role);
        Task<APIResponse<bool>> UpdateInfoAsync(string userId, UpdateUserDto updateUserDto);
        Task<APIResponse<bool>> UpdateUserLocationAsync(Guid userId, UpdateUserLocationRequest request);
    }
}
