using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.Location;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : BaseController<LocationController>
    {
        protected ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<LocationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLocations()
        {
            var response = await _locationService.GetAllLocationsAsync();
            return ProcessResponseMessage(response);
        }


        [HttpGet("getLocationById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<LocationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationById(string id)
        {
            var response = await _locationService.GetLocationByIdAsync(id);
            return ProcessResponseMessage(response);
        }


        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<LocationDto>), StatusCodes.Status200OK)]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var response = await _locationService.CreateLocationAsync(createLocationDto);
            return ProcessResponseMessage(response);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<LocationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLocation(string id, [FromForm] LocationDto updateLocationDto)
        {
            var response = await _locationService.UpdateLocationAsync(id, updateLocationDto);
            return ProcessResponseMessage(response);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var response = await _locationService.DeleteLocationAsync(id);
            return ProcessResponseMessage(response);
        }
    }
}
