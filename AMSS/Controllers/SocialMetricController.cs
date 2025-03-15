using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AMSS.Dto.SocialMetric;
using AMSS.Entities;

namespace AMSS.Controllers
{
    [Route("api/socialMetric")]
    [ApiController]
    [Authorize]
    public class SocialMetricController : BaseController<SocialMetricController>
    {
        private readonly ISocialMetricService _socialMetricService;
        public SocialMetricController(ISocialMetricService socialMetricService)
        {
            _socialMetricService = socialMetricService;
        }

        [HttpGet("getByCode")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<SocialMetricDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSocialMetricsByProvinceCodeAsync([FromQuery]GetSocialMetricByProvinceCodeRequest request)
        {
            var response = await _socialMetricService.GetSocialMetricsByProvinceCode(request);
            return ProcessResponseMessage(response);
        }

        [HttpPost("importData")]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ImportSocialMetric([FromForm] CreateSocialMetricDto createSocialMetric)
        {
            var response = await _socialMetricService.ImportSocialMetricAsync(createSocialMetric);
            return ProcessResponseMessage(response);
        }
    }
}
