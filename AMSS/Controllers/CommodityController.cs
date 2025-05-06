using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Commodities;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/commodity")]
    [ApiController]
    public class CommodityController : BaseController<CommodityController>
    {
        private readonly ICommodityService _commodityService;
        public CommodityController(ICommodityService commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<GetCommoditiesResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCommoditiesAsync([FromQuery] GetCommoditiesRequest request)
        {
            var response = await _commodityService.GetCommoditiesAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetCommoditiesResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCommodityAsync(Guid id)
        {
            var response = await _commodityService.GetCommodityByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCommodityAsync([FromForm] CreateCommodityRequest request)
        {
            var response = await _commodityService.CreateCommodityAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCommodityAsync(Guid id, [FromBody]UpdateCommodityRequest request)
        {
            var response = await _commodityService.UpdateCommodityAsync(id, request);
            return ProcessResponseMessage(response);
        }
    }
}
