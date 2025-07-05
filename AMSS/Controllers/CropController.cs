using AMSS.Dto.Crop;
using AMSS.Dto.Field;
using AMSS.Dto.FieldCrop;
using AMSS.Dto.Requests.Crops;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services;
using AMSS.Services.IService;
using AMSS.Services.IService.IGeneratePdf;
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
        private readonly IHarvestExportService _harvestExportService;
        public CropController(ICropService cropService, IHarvestExportService harvestExportService)
        {
            _cropService = cropService;
            _harvestExportService = harvestExportService;
        }

        [HttpGet("plating-crops")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<CropDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlatingCrops([FromQuery]GetPlantingCropsRequest request)
        {
            var response = await _cropService.GetPlantingCropsAsync(request);
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

        [HttpPost("add-crop-planting")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCropsPlatingField([FromBody] AddPlantingCropRequest addPlantingCropRequest)
        {
            var response = await _cropService.AddPlantingCropsAsync(addPlantingCropRequest);
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

        [HttpDelete("remove-planting-crop")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RemovePlantingCrop([FromQuery] RemovePlantingCropRequest request)
        {
            var response = await _cropService.RemovePlantingCropAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpPost("export-harvest")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExportHarvestInvoiceAsync([FromBody] HarvestExportData request)
        {
            var response = await _harvestExportService.GenerateHarvestExportPdfAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("crop/{cropId:guid}/fields")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<FieldDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFieldsByCropAsync(Guid cropId, [FromQuery] GetFieldsByCropRequest request)
        {
            var response = await _cropService.GetFieldsByCropAsync(AuthenticatedUserId, cropId, request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<CropDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCropsAsync([FromQuery] GetCropsBySupplierRequest request)
        {
            var response = await _cropService.GetCropsAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }
    }
}
