using AMSS.Dto.Responses.Countries;
using AMSS.Entities;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/meta-data")]
    [ApiController]
    public class MetaDataController : BaseController<MetaDataController>
    {
        private readonly IMetatDataService _metatDataService;
        public MetaDataController(IMetatDataService metatDataService)
        {
            _metatDataService = metatDataService;
        }

        [HttpGet("countries")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<CountrySelectionResponse<string>>>),
           StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountriesSelectionAsync()
        {
            var response = await _metatDataService.GetCountriesSelectionAsync();
            return ProcessResponseMessage(response);
        }

        [HttpGet("continents")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<Dictionary<string, string>>),
            StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var response = await _metatDataService.GetCountriesAsync();
            return ProcessResponseMessage(response);
        }

        [HttpGet("{countryCode}/provinces")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<SelectionResponse<string>>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProvincesByCountryCodeAsync(string countryCode)
        {
            var response = await _metatDataService.GetProvincesByCountryCodeAsync(countryCode);
            return ProcessResponseMessage(response);
        }
    }
}
