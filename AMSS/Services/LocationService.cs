using AMSS.Models;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.Location;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AMSS.Services
{
    public class LocationService : BaseService, ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponse<IEnumerable<LocationDto>>> GetAllLocationsAsync()
        {
            try
            {
                var lstLocations = await _unitOfWork.LocationRepository.GetAllAsync();
                var lstLocationDtos = _mapper.Map<IEnumerable<LocationDto>>(lstLocations);
                if (lstLocations == null)
                {
                    return BuildErrorResponseMessage<IEnumerable<LocationDto>>("Failed to get all locations", HttpStatusCode.NotFound);
                }
                return BuildSuccessResponseMessage(lstLocationDtos, "Get all Locations successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<LocationDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<LocationDto>> GetLocationByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<LocationDto>("ID must be valid", HttpStatusCode.NotFound);
                }
                var location = await _unitOfWork.LocationRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (location == null)
                {
                    return BuildErrorResponseMessage<LocationDto>("Not found Location with ID: " + id, HttpStatusCode.NotFound);
                }
                var locationDto = _mapper.Map<LocationDto>(location);
                return BuildSuccessResponseMessage(locationDto, "Get Location by Id successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<LocationDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }


        public async Task<APIResponse<LocationDto>> CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            try
            {
                var newLocation = _mapper.Map<Location>(createLocationDto);
                newLocation.CreatedAt = DateTime.Now;

                await _unitOfWork.LocationRepository.CreateAsync(newLocation);
                _unitOfWork.SaveAsync();
                return BuildSuccessResponseMessage(_mapper.Map<LocationDto>(newLocation), "Location created successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<LocationDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<LocationDto>> UpdateLocationAsync(string id, [FromForm] LocationDto updateLocationDto)
        {
            try
            {
                if (updateLocationDto == null || updateLocationDto.Id.Equals(Guid.Parse(id)))
                {
                    return BuildErrorResponseMessage<LocationDto>("ID must be valid", HttpStatusCode.NotFound);
                }

                var locationFromDb = await _unitOfWork.LocationRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

                if (locationFromDb == null)
                {
                    return BuildErrorResponseMessage<LocationDto>("Not found Location with ID: " + id, HttpStatusCode.NotFound);
                }
                locationFromDb = _mapper.Map<Location>(updateLocationDto);
                locationFromDb.UpdatedAt = DateTime.Now;

                await _unitOfWork.LocationRepository.Update(locationFromDb);
                _unitOfWork.SaveAsync();

                return BuildSuccessResponseMessage(_mapper.Map<LocationDto>(locationFromDb), "Location updated successfully 🌿");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<LocationDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> DeleteLocationAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<bool>("ID must be valid", HttpStatusCode.NotFound);
                }

                var locationFromDb = await _unitOfWork.LocationRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (locationFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("Not found Location with ID: " + id, HttpStatusCode.NotFound);
                }

                await _unitOfWork.LocationRepository.RemoveAsync(locationFromDb);
                _unitOfWork.SaveAsync();

                return BuildSuccessResponseMessage(true, "Location deleted successfully !");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
    }
}
