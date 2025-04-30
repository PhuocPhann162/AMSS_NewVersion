using AMSS.Dto.Farm;
using AMSS.Entities;
using AMSS.Entities.Locations;
using AMSS.Entities.Polygon;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Net;

namespace AMSS.Services
{
    public class FarmService : BaseService, IFarmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FarmService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<APIResponse<IEnumerable<FarmDto>>> GetAllFarmsAsync(string? searchString, int? pageNumber, int? pageSize)
        {
            try
            {
                IEnumerable<Farm> lstFarms = await _unitOfWork.FarmRepository.GetAllAsync(includeProperties: "Location,PolygonApp");

                foreach (var f in lstFarms)
                {
                    f.PolygonApp.Positions = await _unitOfWork.PositionRepository.GetAllAsync(u => u.PolygonAppId == f.PolygonApp.Id);
                }

                var lstFarmsDto = _mapper.Map<IEnumerable<FarmDto>>(lstFarms);


                if (!string.IsNullOrEmpty(searchString))
                {
                    lstFarmsDto = lstFarmsDto.Where(u => u.Name.ToLower().Contains(searchString.ToLower())
                                                        || u.Location.Address.ToLower().Contains(searchString.ToLower())).ToList();
                }

                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    Pagination pagination = new()
                    {
                        CurrentPage = (int)pageNumber,
                        PageSize = (int)pageSize,
                        TotalRecords = lstFarms.Count(),
                    };

                    var paginatedFarm = lstFarmsDto.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
                    return BuildSuccessResponseMessage(paginatedFarm, "Get all Farms successfully", pagination: pagination);
                }
                return BuildSuccessResponseMessage(lstFarmsDto, "Get all Farms successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<FarmDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<FarmDto>> GetFarmByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<FarmDto>("Id must be valid", HttpStatusCode.BadRequest);
                }
                Farm farm = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (farm == null)
                {
                    return BuildErrorResponseMessage<FarmDto>("Not found Farm with ID: " + id, HttpStatusCode.NotFound);
                }
                var farmDto = _mapper.Map<FarmDto>(farm);
                return BuildSuccessResponseMessage(farmDto, "Get Farm with ID: " + id + " successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<FarmDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> CreateFarmAsync(CreateFarmDto createFarmDto)
        {
            // Validate input
            if (createFarmDto == null || createFarmDto.Polygon?.Positions == null || !createFarmDto.Polygon.Positions.Any())
            {
                return BuildErrorResponseMessage<bool>("Invalid input: No positions provided for the polygon.", HttpStatusCode.BadRequest);
            }

            // Create new location
            var newLocation = new Location(createFarmDto.Location);
            await _unitOfWork.LocationRepository.AddAsync(newLocation);

            // Create new polygon
            var newPolygon = new PolygonApp()
            {
                Id = Guid.NewGuid(),
                Color = createFarmDto.Polygon.Color,
                Type = createFarmDto.Polygon.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _unitOfWork.PolygonAppRepository.AddAsync(newPolygon);

            // Add polygon positions (Assuming each position needs to be associated with the polygon)
            var newPositions = new List<Position>();
            foreach (var pos in createFarmDto.Polygon.Positions)
            {
                var newPosition = new Position()
                {
                    Id = Guid.NewGuid(),
                    PolygonAppId = newPolygon.Id,
                    Lat = pos.Lat,
                    Lng = pos.Lng
                };
                newPositions.Add(newPosition);
            }
            await _unitOfWork.PositionRepository.AddRangeAsync(newPositions);

            // Create the farm
            var newFarm = new Farm()
            {
                Id = Guid.NewGuid(),
                Name = createFarmDto.Name.Trim(),
                Area = createFarmDto.Area,
                OwnerName = createFarmDto.OwnerName.Trim(),
                LocationId = newLocation.Id,
                PolygonAppId = newPolygon.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _unitOfWork.FarmRepository.AddAsync(newFarm);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Farm created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<FarmDto>> UpdateFarmAsync(string id, FarmDto updateFarmDto)
        {
            try
            {
                if (updateFarmDto == null || updateFarmDto.Id.Equals(Guid.Parse(id)))
                {
                    return BuildErrorResponseMessage<FarmDto>("Id must be valid", HttpStatusCode.BadRequest);
                }

                var farmFromDb = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

                if (farmFromDb == null)
                {
                    return BuildErrorResponseMessage<FarmDto>("Not found Farm with ID: " + id, HttpStatusCode.NotFound);
                }
                farmFromDb = _mapper.Map<Farm>(updateFarmDto);
                farmFromDb.UpdatedAt = DateTime.Now;

                await _unitOfWork.FarmRepository.Update(farmFromDb);
                await _unitOfWork.SaveChangeAsync();

                return BuildSuccessResponseMessage(_mapper.Map<FarmDto>(farmFromDb), "Farm updated successfully 🌿");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<FarmDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> DeleteFarmAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<bool>("Id must be valid", HttpStatusCode.BadRequest);
                }

                var farmFromDb = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (farmFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("Not found Farm with ID: " + id, HttpStatusCode.NotFound);
                }

                await _unitOfWork.FarmRepository.RemoveAsync(farmFromDb);
                await _unitOfWork.SaveChangeAsync();
                return BuildSuccessResponseMessage(true, "Farm deleted successfully 🌿");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

    }
}
