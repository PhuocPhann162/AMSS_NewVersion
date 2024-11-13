using AMSS.Models.Dto.Polygon;
using AMSS.Models;
using AMSS.Services;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AMSS.Models.Dto.SocialMetric;

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

        [HttpGet("getByCode/{code}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<SocialMetricDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSocialMetricsByCountryCode(string code)
        {
            var response = await _socialMetricService.GetSocialMetricsByCountryCodeAsync(code);
            return ProcessResponseMessage(response);
        }

        [HttpPost("importData")]
        [Produces(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ImportSocialMetric([FromForm] CreateSocialMetricDto createSocialMetric)
        {
            var response = await _socialMetricService.ImportSocialMetricAsync(createSocialMetric);
            return ProcessResponseMessage(response);
        }
    }
}
