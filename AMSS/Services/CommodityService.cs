using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Commodities;
using AMSS.Entities;
using AMSS.Models.Commodities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using System.Net;

namespace AMSS.Services
{
    public class CommodityService : BaseService, ICommodityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommodityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<Guid>> CreateCommodityAsync(CreateCommodityRequest request)
        {
            if(!Guid.TryParse(request.CropId.ToString(), out Guid cropId)) {
                var crop = await _unitOfWork.CropRepository.GetAsync(x => x.Name.Equals(request.Name));
                request.CropId = cropId;
            }
            var commodity = new Commodity(request);

            return BuildSuccessResponseMessage(Guid.NewGuid(), "Commodity created successfully", HttpStatusCode.Created);
        }

        public Task<APIResponse<PaginationResponse<GetCommoditiesResponse>>> GetCommoditiesAsync(GetCommoditiesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<GetCommodityResponse>> GetCommodityByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> UpdateCommodityAsync(Guid id, UpdateCommodityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
