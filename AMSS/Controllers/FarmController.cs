using AMSS.Dto.Farm;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/farm")]
    [ApiController]
    [Authorize]
    public class FarmController : BaseController<FarmController>
    {
        private readonly IFarmService _farmService;
        
        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpGet("getAll")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<FarmDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFarms(string? searchString, int? pageNumber, int? pageSize)
        {
            APIResponse<IEnumerable<FarmDto>> response = await _farmService.GetAllFarmsAsync(searchString, pageNumber, pageSize);
            if (response.Pagination is not null)
            {
                Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(response.Pagination));
            }
            return ProcessResponseMessage(response);
        }

        [HttpGet("getFarmById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FarmDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFarmById(string id)
        {
            var response = await _farmService.GetFarmByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateFarm([FromBody] CreateFarmDto createFarmDto)
        {
            var response = await _farmService.CreateFarmAsync(createFarmDto);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FarmDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateFarm(string id, [FromForm] FarmDto updateFarmDto)
        {
            var response = await _farmService.UpdateFarmAsync(id, updateFarmDto);
            return ProcessResponseMessage(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FarmDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFarm(string id)
        {
            var response = await _farmService.DeleteFarmAsync(id);
            return ProcessResponseMessage(response);
        }
    }
}
