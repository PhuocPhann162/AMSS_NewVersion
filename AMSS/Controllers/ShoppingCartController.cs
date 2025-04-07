using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AMSS.Dto.Responses.ShoppingCarts;
using AMSS.Dto.Requests.ShoppingCarts;

namespace AMSS.Controllers
{
    [Route("api/shopping-cart")]
    [ApiController]
    public class ShoppingCartController : BaseController<ShoppingCartController>
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetShoppingCartResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShoppingCartAsync()
        {
            var response = await _shoppingCartService.GetShoppingCartAsync(AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }

        [HttpPost("add-update-item")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddOrUpdateItemInCartAsync([FromBody] AddOrUpdateItemInCartRequest request, Guid userId)
        {
            var response = await _shoppingCartService.AddOrUpdateItemInCartAsync(request, userId);
            return ProcessResponseMessage(response);
        }

        [HttpPost("apply-coupon")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApplyCouponAsync([FromQuery] ApplyCouponRequest request)
        {
            var response = await _shoppingCartService.ApplyCouponAsync(request, AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }
    }
}
