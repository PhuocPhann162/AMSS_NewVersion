using AMSS.Models;
using AMSS.Models.Dto.Location;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface ILocationService
    {
        Task<APIResponse<IEnumerable<LocationDto>>> GetAllLocationsAsync();
        Task<APIResponse<LocationDto>> GetLocationByIdAsync(string id);
        Task<APIResponse<LocationDto>> CreateLocationAsync(CreateLocationDto createLocationDto);
        Task<APIResponse<LocationDto>> UpdateLocationAsync(string id, [FromForm] LocationDto updateLocationDto);
        Task<APIResponse<bool>> DeleteLocationAsync(string id);
    }
}
