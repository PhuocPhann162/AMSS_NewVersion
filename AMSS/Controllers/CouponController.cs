using AMSS.Dto.Requests.Coupons;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Coupons;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/coupons")]
    [ApiController]
    public class CouponController : BaseController<CouponController>
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<GetCouponsResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCouponsAsync([FromQuery] GetCouponsRequest request)
        {
            var response = await _couponService.GetCouponsAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetCouponResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCouponByIdAsync(Guid id)
        {
            var response = await _couponService.GetCouponByIdAsync(id);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCouponAsync([FromBody] CreateCouponRequest request)
        {
            var response = await _couponService.CreateCouponAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpPut("{id:guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCouponAsync(Guid id, [FromBody] UpdateCouponRequest request)
        {
            var response = await _couponService.UpdateCouponAsync(id, request);
            return ProcessResponseMessage(response);
        }
    }
}
