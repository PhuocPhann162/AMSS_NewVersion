using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Commodities;
using AMSS.Entities;
using AMSS.Models.Commodities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Net;
using AMSS.Models;
using System.Linq.Expressions;
using AMSS.Dto.Suppliers;
using AMSS.Dto.Crop;
using AMSS.Dto.Field;

namespace AMSS.Services
{
    public class CommodityService : BaseService, ICommodityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        public CommodityService(IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<APIResponse<PaginationResponse<GetCommoditiesResponse>>> GetCommoditiesAsync(GetCommoditiesRequest request)
        {
            var sortExpressions = new List<SortExpression<Commodity>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Commodity, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["Name"] = x => x.Name,
                ["Price"] = x => x.Price,
                ["ExpirationDate"] = x => x.ExpirationDate
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Commodity>(sortField, request.OrderByDirection));
            }

            Expression<Func<Commodity, bool>> filter = x =>
                   (request.Categories == null || request.Categories.Count() == 0 || request.Categories.Contains(x.Category)) &&
                   (request.Statuses == null || request.Statuses.Count() == 0 || request.Statuses.Contains(x.Status)) &&
                   (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search));

            var commoditiesPaginationResult = await _unitOfWork.CommodityRepository.GetAsync(
                filter, 
                request.CurrentPage, request.Limit, 
                sortExpressions.ToArray());
            var response = new PaginationResponse<GetCommoditiesResponse>(commoditiesPaginationResult.CurrentPage, commoditiesPaginationResult.Limit,
                            commoditiesPaginationResult.TotalRow, commoditiesPaginationResult.TotalPage)
            {
                Collection = commoditiesPaginationResult.Data.Select(x => new GetCommoditiesResponse
                {
                    Id = x.Id,  
                    Name = x.Name,
                    Description = x.Description,
                    Category = (int)x.Category, 
                    Price = x.Price,
                    Image = x.Image, 
                    ExpirationDate = x.ExpirationDate, 
                    Status = (int)x.Status, 
                    SupplierId = x.SupplierId, 
                    CropId = x.CropId
                })
            };

            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<GetCommodityResponse>> GetCommodityByIdAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetCommodityResponse>("Not valid ID commodity", HttpStatusCode.BadRequest);
            }

            var commodity = await _unitOfWork.CommodityRepository.GetAsync(x => x.Id == id, includeProperties: "Supplier,Crop");
            if(commodity == null)
            {
                return BuildErrorResponseMessage<GetCommodityResponse>("Not found this commodity", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetCommodityResponse>(commodity);
            response.Supplier = _mapper.Map<SupplierDto>(commodity.Supplier);
            response.Crop = _mapper.Map<CropDto>(commodity.Crop);

            return BuildSuccessResponseMessage(response, "Get commodity by ID successfully");
        }

        public async Task<APIResponse<bool>> CreateCommodityAsync(CreateCommodityRequest request)
        {
            if (request.CropId == Guid.Empty || request.SupplierId == Guid.Empty)
            {
                return BuildErrorResponseMessage<bool>("Not valid ID crop", HttpStatusCode.BadRequest);
            }

            // Upload image to cloudinary
            var uploadResult = await _cloudinaryService.UploadImageAsync(request.File);

            var commodity = new Commodity(request);
            commodity.Image = uploadResult.Url;
            commodity.PublicImageId = uploadResult.PublicId;
            await _unitOfWork.CommodityRepository.AddAsync(commodity);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Commodity created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<bool>> UpdateCommodityAsync(Guid id, UpdateCommodityRequest request)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<bool>("Not valid ID commodity", HttpStatusCode.BadRequest);
            }
            var commodity = await _unitOfWork.CommodityRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (commodity == null)
            {
                return BuildErrorResponseMessage<bool>("Not found this commodity", HttpStatusCode.NotFound);
            }
            commodity.Update(request);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Commodity updated successfully", HttpStatusCode.OK);
        }

        public async Task<APIResponse<GetOriginResponse>> GetOriginAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetOriginResponse>("Not valid ID commodity", HttpStatusCode.BadRequest);
            }

            var commodity = await _unitOfWork.CommodityRepository.GetCommodityOriginAsync(id);
            if (commodity == null)
            {
                return BuildErrorResponseMessage<GetOriginResponse>("Not found this commodity", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetOriginResponse>(commodity);
            response.Supplier = _mapper.Map<SupplierDto>(commodity.Supplier);
            response.Crop = _mapper.Map<CropDto>(commodity.Crop);

            var fieldCrops = await _unitOfWork.FieldCropRepository.GetAllAsync(x => x.CropId == response.Crop.Id, includeProperties: "Field,Field.Farm,Field.Location");

            response.Fields = fieldCrops.Select(fc => _mapper.Map<FieldDto>(fc.Field));

            return BuildSuccessResponseMessage(response, "Get commodity by ID successfully");
        }
    }
}
