using AMSS.Dto.Requests.Commodities;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Commodities;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ICommodityService 
    {
        Task<APIResponse<PaginationResponse<GetCommoditiesResponse>>> GetCommoditiesAsync(GetCommoditiesRequest request);
        Task<APIResponse<GetCommodityResponse>> GetCommodityByIdAsync(Guid id);
        Task<APIResponse<bool>> CreateCommodityAsync(CreateCommodityRequest request);
        Task<APIResponse<bool>> UpdateCommodityAsync(Guid id, UpdateCommodityRequest request);
        Task<APIResponse<GetOriginResponse>> GetOriginAsync(Guid id);
    }
}
