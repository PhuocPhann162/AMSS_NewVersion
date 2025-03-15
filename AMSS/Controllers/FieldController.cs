using AMSS.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AMSS.Services.IService;
using System.Net.Mime;
using AMSS.Dto.Field;
using AMSS.Entities;

namespace AMSS.Controllers
{
    [Route("api/field")]
    [ApiController]
    [Authorize]
    public class FieldController : BaseController<FieldController>
    {
        private readonly IFieldService _fieldService;
        
        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet("getAll")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<FieldDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFields(string? searchString, string? status, int? pageNumber, int? pageSize)
        {
            APIResponse<IEnumerable<FieldDto>> response = await _fieldService.GetAllFieldsAsync(searchString, status, pageNumber, pageSize);
            if (response.Pagination is not null)
            {
                Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(response.Pagination));
            }
            return ProcessResponseMessage(response);
        }

        [HttpGet("getFieldById/{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FieldDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFieldById(string id)
        {
            var response = await _fieldService.GetFieldByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FieldDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateField([FromForm] CreateFieldDto createFieldDto)
        {
            var response = await _fieldService.CreateFieldAsync(createFieldDto);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<FieldDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateField(string id, [FromBody] UpdateFieldDto updateFieldDto)
        {
            var response = await _fieldService.UpdateFieldAsync(id, updateFieldDto);
            return ProcessResponseMessage(response);
        }

        [HttpDelete("{id}")]    
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteField(string id)
        {
            var response = await _fieldService.DeleteFieldAsync(id);
            return ProcessResponseMessage(response);
        }
    }
}
