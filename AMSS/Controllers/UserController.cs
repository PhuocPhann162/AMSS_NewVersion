using AMSS.Dto.Requests.Users;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Users;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("customers")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<GetCustomersResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomersAsync([FromQuery] GetCustomersRequest request)
        {
            var response = await _userService.GetCustomersAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpPost("lockUnlock/{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LockUnlockAsync(string? id)
        {
            var response = await _userService.LockUnlockAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost("updateRole/{userId}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RoleManagementAsync([FromQuery] string role)
        {
            var response = await _userService.RoleManagementAsync(AuthenticatedUserId.ToString(), role);
            return ProcessResponseMessage(response);
        }

        [HttpPut("updateInfo/{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInfo([FromBody] UpdateUserDto updateUserDto)
        {
            var response = await _userService.UpdateInfoAsync(AuthenticatedUserId, updateUserDto);
            return ProcessResponseMessage(response);
        }

        [HttpPut("address")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserLocationAsync([FromBody] UpdateUserLocationRequest request)
        {
            var response = await _userService.UpdateUserLocationAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }

        [HttpPut("change-password")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            var response = await _userService.ChangePasswordAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }
    }
}
