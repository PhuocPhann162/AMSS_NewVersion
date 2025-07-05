using AMSS.Dto.Crop;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : BaseController<SupplierController>
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService; 
        }

        [HttpGet("seed-crop")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<GetSuppliersResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSuppliersAsync([FromQuery] GetSuppliersRequest request)
        {
            var response = await _supplierService.GetSuppliersAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("by-role")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<GetSuppliersByRoleResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSuppliersByRoleAsync(Role role)
        {
            var response = await _supplierService.GetSuppliersByRoleAsync(role);
            return ProcessResponseMessage(response);
        }

        [HttpGet("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetSuppliersByRoleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSupplierAsync(Guid id)
        {
            var response = await _supplierService.GetSupplierByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSupplierAsync([FromBody] CreateSupplierRequest request)
        {
            var response = await _supplierService.CreateSupplierAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCommodityAsync(Guid id, [FromBody] UpdateSupplierRequest request)
        {
            var response = await _supplierService.UpdateSupplierAsync(id, request);
            return ProcessResponseMessage(response);
        }

        
    }
}
