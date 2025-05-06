using AMSS.Dto.Crop;
using AMSS.Dto.FieldCrop;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/crop")]
    [ApiController]
    public class CropController : BaseController<CropController>
    {
       private readonly ICropService _cropService;
        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<CropDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCrops()
        {
            var response = await _cropService.GetCropsAsync();
            return ProcessResponseMessage(response);
        }

        [HttpGet("getCropById/{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<CropDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCropById(string id)
        {
            var response = await _cropService.GetCropByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpGet("getAllByFieldId/{fieldId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<FieldCropDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCropsByFieldId(string fieldId)
        {
            var response = await _cropService.GetCropsByFieldIdAsync(fieldId);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCrop([FromForm] CreateCropDto createCropDto)
        {
            var response = await _cropService.CreateCropAsync(createCropDto);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCrop(string id, [FromForm] UpdateCropDto updateCropDto)
        {
            var response = await _cropService.UpdateCropAsync(id, updateCropDto);
            return ProcessResponseMessage(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCrop(string id)
        {
            var response = await _cropService.DeleteCropAsync(id);
            return ProcessResponseMessage(response);
        }
    }
}
