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
        [HttpGet("getAll")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers(string? searchString, int pageNumber = 1, int pageSize = 5)
        {
            APIResponse<IEnumerable<UserDto>> response = await _userService.GetAllUsersAsync(searchString, pageNumber, pageSize);
            if (response.Pagination is not null)
            {
                Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(response.Pagination));
            }
            return ProcessResponseMessage(response);
        }


        [HttpPost("lockUnlock/{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LockUnlock(string? id)
        {
            var response = await _userService.LockUnlockAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost("updateRole/{userId}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RoleManagement(string userId, [FromForm] string role)
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
