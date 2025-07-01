using AMSS.Dto.Requests.CareLogs;
using AMSS.Dto.Requests.Commodities;
using AMSS.Entities;
using AMSS.Services;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/care-process")]
    [ApiController]
    [Authorize]
    public class CareLogController : BaseController<CareLogController>
    {
        private readonly ICareLogService _careLogService;

        public CareLogController(ICareLogService careLogService) 
        {
            _careLogService = careLogService;
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
