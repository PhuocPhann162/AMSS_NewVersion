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

        public async Task<APIResponse<FieldDto>> CreateFieldAsync(CreateFieldDto createFieldDto)
        {
            try
            {
                var newField = _mapper.Map<Field>(createFieldDto);

                newField.Status = String.IsNullOrEmpty(newField.Status) ? SD.Status_Idle : newField.Status;
                newField.CreatedAt = DateTime.Now;

                await _unitOfWork.FieldRepository.CreateAsync(newField);
                await _unitOfWork.SaveChangeAsync();
                return BuildSuccessResponseMessage(_mapper.Map<FieldDto>(newField), "Field created successfully", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<FieldDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
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
    }
}
