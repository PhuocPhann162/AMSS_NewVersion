using AMSS.Dto.Requests.CareLogs;
using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses.Commodities;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Services;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AMSS.Dto.CareLog;

namespace AMSS.Controllers
{
    [Route("api/care-logs")]
    [ApiController]
    [Authorize]
    public class CareLogController : BaseController<CareLogController>
    {
        private readonly ICareLogService _careLogService;

        public CareLogController(ICareLogService careLogService) 
        {
            _careLogService = careLogService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<CareLogDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCareLogsAsync([FromQuery] GetCareLogsRequest request)
        {
            var response = await _careLogService.GetCareLogsAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCareLogAsync([FromBody] CreateCareLogRequest request)
        {
            var response = await _careLogService.CreateCareLogAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }
    }
}
