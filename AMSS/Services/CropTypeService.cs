using AMSS.Dto.Crop;
using AMSS.Dto.CropType;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Net;

namespace AMSS.Services
{
    public class CropTypeService : BaseService, ICropTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CropTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<IEnumerable<CropTypeDto>>> GetAllCropTypesAsync(string? searchString, int? pageNumber, int? pageSize)
        {
            IEnumerable<CropType> cropTypes = await _unitOfWork.CropTypeRepository.GetAllWithDetailsAsync();
            cropTypes = cropTypes.OrderByDescending(c => c.CreatedAt);
            //var lstCropTypeDtos = _mapper.Map<IEnumerable<CropTypeDto>>(cropTypes);
            var cropTypeDtos = cropTypes.Select(x => new CropTypeDto()
            {
                Id = x.Id, 
                Name = x.Name,
                Code = x.Code,
                Type = x.Type,
                CreatedAt = x.CreatedAt,
                Crops = _mapper.Map<IEnumerable<CropDto>>(x.Crops)
            });

            if (!string.IsNullOrEmpty(searchString))
            {
                cropTypeDtos = cropTypeDtos.Where(u => u.Name!.ToLower().Contains(searchString.ToLower()) || u.Code!.ToLower().Contains(searchString.ToLower())).ToList();
            }
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                Pagination pagination = new()
                {
                    CurrentPage = (int)pageNumber,
                    PageSize = (int)pageSize,
                    TotalRecords = cropTypeDtos.Count()
                };

                var paginatedCropType = cropTypeDtos.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
                return BuildSuccessResponseMessage(paginatedCropType, "Get all Crops successfully", pagination: pagination);
            }
            return BuildSuccessResponseMessage(cropTypeDtos, "Get all Crops successfully");
        }

        public async Task<APIResponse<CropTypeDto>> CreateCropTypeAsync(CreateCropTypeDto createCropTypeDto)
        {
            try
            {
                if (createCropTypeDto.Name == null)
                {
                    return BuildErrorResponseMessage<CropTypeDto>("Name Type is required", HttpStatusCode.BadRequest);
                }

                var newCropType = _mapper.Map<CropType>(createCropTypeDto);
                newCropType.CreatedAt = DateTime.Now;
                newCropType.UpdatedAt = DateTime.Now;

                await _unitOfWork.CropTypeRepository.AddAsync(newCropType);
                await _unitOfWork.SaveChangeAsync();

                var newCropTypeDto = _mapper.Map<CropTypeDto>(newCropType);

                return BuildSuccessResponseMessage(newCropTypeDto, "Crop Type created successfully", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<CropTypeDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
    }
}
