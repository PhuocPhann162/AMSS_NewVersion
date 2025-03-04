using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.CropType;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/cropType")]
    [ApiController]
    [Authorize]
    public class CropTypeController : BaseController<CropTypeController>
    {
        private readonly ICropTypeService _cropTypeService;
        public CropTypeController(ICropTypeService cropTypeService)
        {
            _cropTypeService = cropTypeService;
        }

        [HttpGet("getAllCropTypes")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<CropTypeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCropTypes(string? searchString, int? pageNumber, int? pageSize)
        {
            APIResponse<IEnumerable<CropTypeDto>> response = await _cropTypeService.GetAllCropTypesAsync(searchString, pageNumber, pageSize);
            if (response.Pagination is not null)
            {
                Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(response.Pagination));
            }
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<CropTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCropType([FromForm] CreateCropTypeDto createCropTypeDto)
        {
            var response = await _cropTypeService.CreateCropTypeAsync(createCropTypeDto);
            return ProcessResponseMessage(response);
        }
    }
}
