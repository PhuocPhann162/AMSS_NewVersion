using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Commodities;
using AMSS.Entities;
using AMSS.Models.Commodities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class CommodityService : BaseService, ICommodityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommodityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<APIResponse<Guid>> CreateCommodityAsync(CreateCommodityRequest request)
        {
            throw new NotImplementedException();
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
