using AMSS.Dto.Responses.Commodities;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AMSS.Dto.Requests.Orders;
using AMSS.Dto.Responses.Orders;

namespace AMSS.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : BaseController<OrderController>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<GetOrdersResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] GetOrdersRequest request)
        {
            var response = await _orderService.GetOrdersAsync(request, AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }

        [HttpGet("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetCommoditiesResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            var response = await _orderService.GetOrderByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderRequest request)
        {
            var response = await _orderService.CreateOrderAsync(request, AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateOrderAsync(Guid id, [FromBody] UpdateOrderRequest request)
        {
            var response = await _orderService.UpdateOrderAsync(id, request, AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }

    }
}
