using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.User;
using AMSS.Repositories;
using AMSS.Repositories.IRepository;
using AMSS.Repository.IRepository;
using AMSS.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        protected APIResponse _response;
        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _response = new APIResponse();
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize]
        [HttpGet("getAll")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> GetAllUsers(string? searchString, int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                List<ApplicationUser> lstUsers = await _unitOfWork.UserRepository.GetAllAsync(u => !u.IsDeleted);

                if (lstUsers == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Something wrong when get all users");
                    return BadRequest(_response);
                }

                foreach (var user in lstUsers)
                {
                    user.Role = Enum.Parse<Role>(_userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()!);
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    lstUsers = lstUsers.Where(u => u.FullName.ToLower().Contains(searchString.ToLower()) || u.PhoneNumber.Contains(searchString) || u.Role.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                }

                Pagination pagination = new()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = lstUsers.Count(),
                };
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = lstUsers.Skip((pageNumber - 1) * pageSize).Take(pageSize);
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


        [HttpPost("lockUnlock/{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> LockUnlock(string? id)
        {
            try
            {
                var userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id && !u.IsDeleted);
                if (userFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Errors while lock/unlock this user");
                    return BadRequest(_response);
                }
                if (!userFromDb.IsActive)
                {
                    // user is currently locked and we need to unlock them 
                    userFromDb.IsActive = true;
                    userFromDb.UpdatedAt = DateTime.Now;
                    await _unitOfWork.UserRepository.Update(userFromDb);
                    _unitOfWork.SaveAsync();
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.SuccessMessage = "Unlock this user successfully";
                }
                else
                {
                    userFromDb.IsActive = false;
                    userFromDb.UpdatedAt = DateTime.Now;
                    await _unitOfWork.UserRepository.Update(userFromDb);
                    _unitOfWork.SaveAsync();
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.SuccessMessage = "Lock this user successfully";
                }
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Something wrong when lock/unlock user");
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost("updateRole/{userId}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> RoleManagement(string userId, [FromForm] string role)
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
                _response.SuccessMessage = "Update this user's permission successfully";
                _response.Result = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Something wrong when update user role");
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [Authorize]
        [HttpPut("updateInfo/{userId}")]
        public async Task<ActionResult<APIResponse>> UpdateInfo(string userId, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(userId) || updateUserDto == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessages.Add("Invalid User ID");
                        return StatusCode(StatusCodes.Status500InternalServerError, _response);
                    }
                    ApplicationUser userFromDb = await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId && !u.IsDeleted, false);
                    if (userFromDb == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.ErrorMessages.Add("Not found this user");
                        return NotFound(_response);
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
                    _unitOfWork.SaveAsync();

                    _response.SuccessMessage = "Update this user information successfully";
                    _response.Result = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Something wrong when updating User Info");
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Something wrong when update user role");
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
