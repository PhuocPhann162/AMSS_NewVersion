using AMSS.Dto.Crop;
using AMSS.Dto.Farm;
using AMSS.Dto.Field;
using AMSS.Dto.FieldCrop;
using AMSS.Dto.Location;
using AMSS.Dto.Requests.Crops;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Linq.Expressions;
using System.Net;

namespace AMSS.Services
{
    public class CropService : BaseService, ICropService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public CropService(IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<APIResponse<PaginationResponse<CropDto>>> GetPlantingCropsAsync(GetPlantingCropsRequest request)
        {
            var sortExpressions = new List<SortExpression<Crop>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Crop, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["Name"] = x => x.Name,
            };

            // Sort
            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Crop>(sortField, request.OrderByDirection));
            }

            // Filter and Search
            Expression<Func<Crop, bool>> filter = x =>
                    (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search) || x.Name.Contains(request.Search));

            var cropsPaginationResult = await _unitOfWork.CropRepository.GetPaginationIncludeAsync(
                filter,
                request.CurrentPage,
                request.Limit,
                sortExpressions.ToArray(),
                includes: [x => x.CropType]);
            var response = new PaginationResponse<CropDto>(cropsPaginationResult.CurrentPage, cropsPaginationResult.Limit,
                            cropsPaginationResult.TotalRow, cropsPaginationResult.TotalPage)
            {
                Collection = cropsPaginationResult.Data.Select(x => new CropDto
                {
                    Id = x.Id,
                    Icon = x.Icon,
                    Name = x.Name,
                    Cycle = x.Cycle,
                    Edible = x.Edible,
                    Soil = x.Soil,
                    Watering = x.Watering,
                    Maintenance = x.Maintenance,
                    HardinessZone = x.HardinessZone,
                    Indoor = x.Indoor,
                    Propagation = x.Propagation,
                    CareLevel = x.CareLevel,
                    GrowthRate = x.GrowthRate,
                    Description = x.Description,
                    CultivatedArea = x.CultivatedArea,
                    PlantedDate = x.PlantedDate,
                    ExpectedDate = x.ExpectedDate,
                    Quantity = x.Quantity,
                    CropTypeName = x.CropType.Type,
                    CreatedAt = x.CreatedAt
                })
            };
            return BuildSuccessResponseMessage(response);
        }
        public async Task<APIResponse<CropDto>> GetCropByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BuildErrorResponseMessage<CropDto>("Oops ! Not Found Crop ID", HttpStatusCode.NotFound);
            }
            var crop = await _unitOfWork.CropRepository
                .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "CropType,Supplier");
            var cropDto = _mapper.Map<CropDto>(crop);
            if (crop == null)
            {
                return BuildErrorResponseMessage<CropDto>("Oops ! Something wrong when get crop by id", HttpStatusCode.NotFound);
            }
            return BuildSuccessResponseMessage(cropDto, "Get Crop by Id successfully");
        }

        public async Task<APIResponse<IEnumerable<FieldCropDto>>> GetCropsByFieldIdAsync(string fieldId)
        {
            try
            {
                var fieldCropFromDb = await _unitOfWork.FieldCropRepository
                    .GetAllAsync(u => u.FieldId.Equals(Guid.Parse(fieldId)), includeProperties: "Crop");

                if (fieldCropFromDb == null)
                {
                    return BuildErrorResponseMessage<IEnumerable<FieldCropDto>>("Oops ! Something wrong when get crop by id", HttpStatusCode.NotFound);

                }
                var fieldCropDto = _mapper.Map<IEnumerable<FieldCropDto>>(fieldCropFromDb);

                return BuildSuccessResponseMessage(fieldCropDto, "Get Crop by FieldId successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<FieldCropDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> CreateCropAsync(CreateCropDto createCropDto)
        {
            if (createCropDto.File == null || createCropDto.File.Length == 0)
            {
                return BuildErrorResponseMessage<bool>("File is required", HttpStatusCode.NotFound);
            }

            var newCropType = new CropType()
            {
                Id = Guid.NewGuid(),
                Name = createCropDto.Name,
                Code = GenerateCode(createCropDto.Name),
                Type = createCropDto.CropTypeName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _unitOfWork.CropTypeRepository.AddAsync(newCropType);

            var newCrop = _mapper.Map<Crop>(createCropDto);
            newCrop.CropTypeId = newCropType.Id;
            newCrop.CropType = newCropType;
            newCrop.CreatedAt = DateTime.Now;
            newCrop.UpdatedAt = DateTime.Now;

            if (createCropDto.File != null && createCropDto.File.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(createCropDto.File);
                newCrop.Icon = uploadResult.Url;
                newCrop.PublicImageId = uploadResult.PublicId;
            }

            await _unitOfWork.CropRepository.AddAsync(newCrop);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Crop created successfully", HttpStatusCode.Created);
        }

        public static string GenerateCode(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1)
            {
                return $"{char.ToUpper(name[0])}{char.ToUpper(name[^1])}";
            }
            else
            {
                return string.Concat(words.Select(w => char.ToUpper(w[0])));
            }
        }

        public async Task<APIResponse<bool>> UpdateCropAsync(string id, UpdateCropDto updateCropDto)
        {

            if (updateCropDto == null || !updateCropDto.Id.Equals(Guid.Parse(id)))
            {
                return BuildErrorResponseMessage<bool>("Update crop request does not exist!", HttpStatusCode.NotFound);
            }

            var cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

            if (cropFromDb == null)
            {
                return BuildErrorResponseMessage<bool>("This crop does not exist!", HttpStatusCode.NotFound);
            }
            cropFromDb = _mapper.Map<Crop>(updateCropDto);
            cropFromDb.UpdatedAt = DateTime.Now;

            if (updateCropDto.File != null && updateCropDto.File.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(updateCropDto.File);
                cropFromDb.Icon = uploadResult.Url;
            }
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Crop updated successfully");
        }

        public async Task<APIResponse<bool>> DeleteCropAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BuildErrorResponseMessage<bool>("ID not found!", HttpStatusCode.NotFound);
            }

            var cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
            if (cropFromDb == null)
            {
                return BuildErrorResponseMessage<bool>("This crop does not exist!", HttpStatusCode.NotFound);
            }

            await _cloudinaryService.DeleteImageAsync(cropFromDb.PublicImageId);
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);

            await _unitOfWork.CropRepository.RemoveAsync(cropFromDb);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Crop deleted successfully !");
        }

        public async Task<APIResponse<bool>> AddPlantingCropsAsync(AddPlantingCropRequest addPlantingCropRequest)
        {
            var fieldCrops = new FieldCrop()
            {
                Id = Guid.NewGuid(),
                FieldId = addPlantingCropRequest.FieldId,
                CropId = addPlantingCropRequest.CropId,
                Quantity = addPlantingCropRequest.Quantity,
                Status = addPlantingCropRequest.Status,
                Unit = addPlantingCropRequest.Unit,
                Notes = addPlantingCropRequest.Notes.Trim() ?? string.Empty,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.FieldCropRepository.CreateAsync(fieldCrops);
            return BuildSuccessResponseMessage(true, "Add plating crops successfully");
        }

        public async Task<APIResponse<bool>> RemovePlantingCropAsync(RemovePlantingCropRequest request)
        {
            var fieldCrop = await _unitOfWork.FieldCropRepository.GetAsync(
                x => x.FieldId == request.FieldId && x.CropId == request.CropId);

            if (fieldCrop == null)
            {
                return BuildErrorResponseMessage<bool>("Planting crop not found", HttpStatusCode.NotFound);
            }

            await _unitOfWork.FieldCropRepository.RemoveAsync(fieldCrop);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Planting crop removed successfully");
        }

        public async Task<APIResponse<PaginationResponse<FieldDto>>> GetFieldsByCropAsync(Guid supplierId, Guid cropId, GetFieldsByCropRequest request)
        {
            var crop = await _unitOfWork.CropRepository.GetByIdAsync(cropId);
            if (crop is null)
            {
                return BuildErrorResponseMessage<PaginationResponse<FieldDto>>("Not valid ID crop", HttpStatusCode.BadRequest);
            }

            var sortExpressions = new List<SortExpression<FieldCrop>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<FieldCrop, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<FieldCrop>(sortField, request.OrderByDirection));
            }

            Expression<Func<FieldCrop, bool>> filter = x =>
                   (x.CropId == cropId) &&
                   (string.IsNullOrEmpty(request.Search) || x.Field.Name.Contains(request.Search));

            var cropsPaginationResult = await _unitOfWork.FieldCropRepository.GetPaginationIncludeAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray(),
                includes: [x => x.Field, x => x.Field.Location,
                            x => x.Field.Farm]);

            var response = new PaginationResponse<FieldDto>(cropsPaginationResult.CurrentPage, cropsPaginationResult.Limit,
                            cropsPaginationResult.TotalRow, cropsPaginationResult.TotalPage)
            {
                Collection = cropsPaginationResult.Data.Select(x => new FieldDto
                {
                    Id = x.Field.Id,
                    Name = x.Field.Name, 
                    Area = x.Field.Area,
                    Status = x.Field.Status,
                    InternalId = x.Field.InternalId,
                    PlantingFormat = x.Field.PlantingFormat,
                    LocationType = x.Field.LocationType,
                    LightProfile = x.Field.LightProfile,
                    GrazingRestDays = x.Field.GrazingRestDays,
                    NumberOfBeds = x.Field.NumberOfBeds,
                    BedLength = x.Field.BedLength,
                    BedWidth = x.Field.BedWidth,
                    CreatedAt = x.CreatedAt,
                    Location = _mapper.Map<LocationDto>(x.Field.Location),
                    Farm = _mapper.Map<FarmDto>(x.Field.Farm),
                })
            };

            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<PaginationResponse<CropDto>>> GetCropsAsync(Guid userId, GetCropsBySupplierRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId.ToString());
            if (user is null)
            {
                return BuildErrorResponseMessage<PaginationResponse<CropDto>>("Not valid ID user", HttpStatusCode.BadRequest);
            }

            var sortExpressions = new List<SortExpression<Crop>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Crop, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["Name"] = x => x.Name,
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Crop>(sortField, request.OrderByDirection));
            }

            Expression<Func<Crop, bool>> filter = x =>
                   (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search));

            var cropsPaginationResult = await _unitOfWork.CropRepository.GetAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<CropDto>(cropsPaginationResult.CurrentPage, cropsPaginationResult.Limit,
                            cropsPaginationResult.TotalRow, cropsPaginationResult.TotalPage)
            {
                Collection = cropsPaginationResult.Data.Select(x => new CropDto
                {
                    Id = x.Id,
                    Icon = x.Icon,
                    Name = x.Name,
                    Cycle = x.Cycle,
                    Edible = x.Edible,
                    Soil = x.Soil,
                    Watering = x.Watering,
                    Maintenance = x.Maintenance,
                    HardinessZone = x.HardinessZone,
                    Indoor = x.Indoor,
                    Propagation = x.Propagation,
                    CareLevel = x.CareLevel,
                    GrowthRate = x.GrowthRate,
                    Description = x.Description,
                    CultivatedArea = x.CultivatedArea,
                    PlantedDate = x.PlantedDate,
                    ExpectedDate = x.ExpectedDate,
                    Quantity = x.Quantity
                })
            };

            return BuildSuccessResponseMessage(response);
        }
    }

}
