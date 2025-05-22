using AMSS.Dto.Field;
using AMSS.Entities;
using AMSS.Entities.Locations;
using AMSS.Entities.Polygon;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Utility;
using AutoMapper;
using System.Net;

namespace AMSS.Services
{
    public class FieldService : BaseService, IFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FieldService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponse<IEnumerable<FieldDto>>> GetAllFieldsAsync(string? searchString, string? status, int? pageNumber, int? pageSize)
        {
            try
            {
                IEnumerable<Field> lstFields = await _unitOfWork.FieldRepository.GetAllAsync(includeProperties: "Location,PolygonApp,FieldCrops,Farm");

                foreach (var f in lstFields)
                {
                    f.PolygonApp.Positions = await _unitOfWork.PositionRepository.GetAllAsync(u => u.PolygonAppId == f.PolygonApp.Id);
                }

                var lstFieldsDto = _mapper.Map<IEnumerable<FieldDto>>(lstFields);


                if (!string.IsNullOrEmpty(searchString))
                {
                    lstFieldsDto = lstFieldsDto.Where(u => u.Name.ToLower().Contains(searchString.ToLower())
                                                    || u.Farm.Name.ToLower().Contains(searchString.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(status))
                {
                    lstFieldsDto = lstFieldsDto.Where(u => u.Status.ToLower() == status.ToLower());
                }

                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    Pagination pagination = new()
                    {
                        CurrentPage = (int)pageNumber,
                        PageSize = (int)pageSize,
                        TotalRecords = lstFieldsDto.Count(),
                    };

                    var paginatedField = lstFieldsDto.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
                    return BuildSuccessResponseMessage(paginatedField, "Get all Fields successfully", pagination: pagination);
                }
                return BuildSuccessResponseMessage(lstFieldsDto, "Get all Fields successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<FieldDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<FieldDto>> GetFieldByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<FieldDto>("Id must be valid", HttpStatusCode.BadRequest);
                }
                Field fieldFromDb = await _unitOfWork.FieldRepository
                    .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "Location,PolygonApp,Farm,SoilQuality");
                if (fieldFromDb == null)
                {
                    return BuildErrorResponseMessage<FieldDto>("Not found Field with ID: " + id, HttpStatusCode.NotFound);
                }
                fieldFromDb.PolygonApp.Positions = await _unitOfWork.PositionRepository
                                .GetAllAsync(u => u.PolygonAppId == fieldFromDb.PolygonApp.Id);
                var fieldDto = _mapper.Map<FieldDto>(fieldFromDb);
                return BuildSuccessResponseMessage(fieldDto, "Get all Fields successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<FieldDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> CreateFieldAsync(CreateFieldDto createFieldDto)
        {
            // Validate input
            if (createFieldDto == null || createFieldDto.Polygon?.Positions == null || !createFieldDto.Polygon.Positions.Any())
            {
                return BuildErrorResponseMessage<bool>("Invalid input: No positions provided for the polygon.", HttpStatusCode.BadRequest);
            }

            // Create new location
            var newLocation = new Location(createFieldDto.Location);
            await _unitOfWork.LocationRepository.AddAsync(newLocation);

            // Create new polygon
            var newPolygon = new PolygonApp()
            {
                Id = Guid.NewGuid(),
                Color = createFieldDto.Polygon.Color,
                Type = createFieldDto.Polygon.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _unitOfWork.PolygonAppRepository.AddAsync(newPolygon);

            // Add polygon positions (Assuming each position needs to be associated with the polygon)
            var newPositions = new List<Position>();
            foreach (var pos in createFieldDto.Polygon.Positions)
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


            if (createFieldDto.FieldId == Guid.Empty)
            {
                // Create the field
                var newField = new Field()
                {
                    Id = Guid.NewGuid(),
                    Name = createFieldDto.Name.Trim(),
                    Area = createFieldDto.Area,
                    Status = SD.Status_Idle,
                    FarmId = createFieldDto.FarmId,
                    LocationId = newLocation.Id,
                    PolygonAppId = newPolygon.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                await _unitOfWork.FieldRepository.AddAsync(newField);
            }
            else
            {
                // Update existing field 
                var field = await _unitOfWork.FieldRepository.FirstOrDefaultAsync(x => x.Id == createFieldDto.FieldId);
                if (field is null) {
                    return BuildErrorResponseMessage<bool>("This field is not exist", HttpStatusCode.BadRequest);
                }
                field.FarmId = createFieldDto.FarmId;
                field.Area = createFieldDto.Area;
                field.LocationId = newLocation.Id;
                field.PolygonAppId = newPolygon.Id;
                field.UpdatedAt = DateTime.Now;
            }

            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Field created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<FieldDto>> UpdateFieldAsync(string id, UpdateFieldDto updateFieldDto)
        {
            try
            {
                if (updateFieldDto == null || !updateFieldDto.Id.Equals(Guid.Parse(id)))
                {
                    return BuildErrorResponseMessage<FieldDto>("Id must be valid", HttpStatusCode.BadRequest);
                }

                Field fieldFromDb = await _unitOfWork.FieldRepository
                    .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "Location,PolygonApp");

                if (fieldFromDb == null)
                {
                    return BuildErrorResponseMessage<FieldDto>("Not found Field with ID: " + id, HttpStatusCode.NotFound);
                }

                if (updateFieldDto.Positions != null)
                {
                    fieldFromDb.PolygonApp.Positions.Clear();

                    foreach (var positionDto in updateFieldDto.Positions)
                    {

                        fieldFromDb.PolygonApp.Positions.Add(_mapper.Map<Position>(positionDto));
                    }

                    await _unitOfWork.PolygonAppRepository.Update(fieldFromDb.PolygonApp);

                }

                if (updateFieldDto.Location != null)
                {
                    // Update Field Location
                    var locationFromDb = _unitOfWork.LocationRepository
                        .GetAsync(u => u.Id == fieldFromDb.LocationId).GetAwaiter().GetResult();
                    locationFromDb = _mapper.Map<Location>(updateFieldDto.Location);
                    await _unitOfWork.LocationRepository.Update(fieldFromDb.Location);
                }

                // Update Field Props
                if (!string.IsNullOrEmpty(updateFieldDto.Name))
                {
                    fieldFromDb.Name = updateFieldDto.Name;
                }

                if (!string.IsNullOrEmpty(updateFieldDto.Status))
                {
                    fieldFromDb.Status = updateFieldDto.Status;
                }

                if (updateFieldDto.Area > 0)
                {
                    fieldFromDb.Area = updateFieldDto.Area;
                }

                fieldFromDb.UpdatedAt = DateTime.Now;

                await _unitOfWork.FieldRepository.Update(fieldFromDb);
                await _unitOfWork.SaveChangeAsync();

                return BuildSuccessResponseMessage(_mapper.Map<FieldDto>(fieldFromDb), "Field updated successfully 🌿");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<FieldDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> DeleteFieldAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<bool>("Id must be valid", HttpStatusCode.BadRequest);
                }

                Field fieldFromDb = await _unitOfWork.FieldRepository
                    .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "Location,PolygonApp");
                List<Position> lstPositionsFromDb = await _unitOfWork.PositionRepository.GetAllAsync(u => u.PolygonAppId == fieldFromDb.PolygonAppId);
                // Delete Location 
                await _unitOfWork.LocationRepository.RemoveAsync(fieldFromDb.Location);

                // Delete Positions
                foreach (Position pos in lstPositionsFromDb)
                {
                    await _unitOfWork.PositionRepository.RemoveAsync(pos);
                }

                // Delete PolygonApp 
                await _unitOfWork.PolygonAppRepository.RemoveAsync(fieldFromDb.PolygonApp);



                if (fieldFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("Not found Field with ID: " + id, HttpStatusCode.NotFound);
                }

                await _unitOfWork.FieldRepository.RemoveAsync(fieldFromDb);
                await _unitOfWork.SaveChangeAsync();
                return BuildSuccessResponseMessage(true, "Field deleted successfully 🌿");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<Guid>> CreateGrowLocationAsync(CreateGrowLocationDto createGrowLocationDto)
        {
            // Validate input
            if (createGrowLocationDto == null)
            {
                return BuildErrorResponseMessage<Guid>("Invalid input: No request to proceed.", HttpStatusCode.BadRequest);
            }

            // Create the field
            var newField = new Field
            {
                Id = Guid.NewGuid(),
                Name = createGrowLocationDto.Name?.Trim(),
                InternalId = createGrowLocationDto.InternalId?.Trim(),
                LocationType = createGrowLocationDto.LocationType?.Trim(),
                PlantingFormat = createGrowLocationDto.PlantingFormat?.Trim(),
                NumberOfBeds = createGrowLocationDto.NumberOfBeds ?? 0,
                BedLength = (decimal?)createGrowLocationDto.BedLength ?? 0,
                BedWidth = (decimal?)(createGrowLocationDto.BedWidth ?? 0),
                Status = createGrowLocationDto.Status?.Trim(),
                LightProfile = createGrowLocationDto.LightProfile?.Trim(),
                GrazingRestDays = (int)createGrowLocationDto.GrazingRestDays,
                Description = createGrowLocationDto.Description?.Trim(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _unitOfWork.FieldRepository.AddAsync(newField);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(newField.Id, "Field created successfully", HttpStatusCode.Created);
        }
    }
}
