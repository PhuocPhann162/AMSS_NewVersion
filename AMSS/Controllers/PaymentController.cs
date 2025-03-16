using AMSS.Dto.Responses.Payment;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : BaseController<PaymentController>
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<MakePaymentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakePaymentAsync()
        {
            var response = await _paymentService.MakePaymentAsync(AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }
    }
}
