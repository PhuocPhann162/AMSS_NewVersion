using AMSS.Dto.Requests.Reports;
using AMSS.Dto.Responses.Reports;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : BaseController<ReportController>
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("revenue")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetRevenueResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRevenueAsync([FromQuery]GetRevenueRequest request)
        {
            var response = await _reportService.GetRevenueAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("orders-statistic")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetRevenueResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GeOrderStatisticAsync([FromQuery] GetRevenueRequest request)
        {
            var response = await _reportService.GetOrderStatisticAsync(request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("total-statistic")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<GetTotalStatisticResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToTalStatisticAsync([FromQuery] GetTotalStatisticRequest request)
        {
            var response = await _reportService.GetToTalStatisticAsync(request);
            return ProcessResponseMessage(response);
        }
    }
}
