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

            if(!string.IsNullOrEmpty(request.OrderBy) && 
                string.Equals(request.OrderBy, "CreatedAt", StringComparison.OrdinalIgnoreCase))
            {
                var sortExpression = new SortExpression<Commodity>(p => p.CreatedAt, request.OrderByDirection);
                sortExpressions.Add(sortExpression);
            }

            var commoditiesPaginationResult = await _unitOfWork.CommodityRepository.GetAsync(null, request.CurrentPage, request.Limit, sortExpressions.ToArray());
            var response = new PaginationResponse<GetCommoditiesResponse>(commoditiesPaginationResult.CurrentPage, commoditiesPaginationResult.Limit,
                            commoditiesPaginationResult.TotalRow, commoditiesPaginationResult.TotalPage)
            {
                Collection = commoditiesPaginationResult.Data.Select(x => new GetCommoditiesResponse
                {
                    Id = x.Id,  
                    Name = x.Name,
                    Description = x.Description,
                    Category = x.Category, 
                    Price = x.Price,
                    Image = x.Image, 
                    ExpirationDate = x.ExpirationDate, 
                    Status = x.Status, 
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

            var commodity = await _unitOfWork.CommodityRepository.FirstOrDefaultAsync(x => x.Id == id);
            if(commodity == null)
            {
                return BuildErrorResponseMessage<GetCommodityResponse>("Not found this commodity", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetCommodityResponse>(commodity);

            return BuildSuccessResponseMessage(response, "Get commodity by ID successfully", HttpStatusCode.Created);
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
    }
}
