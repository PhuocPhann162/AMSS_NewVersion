using AMSS.Dto.Requests.Users;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Users;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
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
        public async Task<IActionResult> RoleManagementAsync(string userId, [FromForm] string role)
        {
            var response = await _userService.RoleManagementAsync(userId, role);
            return ProcessResponseMessage(response);
        }

        [Authorize]
        [HttpPut("updateInfo/{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInfo(string userId, [FromBody] UpdateUserDto updateUserDto)
        {
            var response = await _userService.UpdateInfoAsync(userId, updateUserDto);
            return ProcessResponseMessage(response);
        }
    }
}
