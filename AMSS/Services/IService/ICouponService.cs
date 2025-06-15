using AMSS.Dto.Requests.Coupons;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Coupons;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ICouponService
    {
        Task<APIResponse<PaginationResponse<GetCouponsResponse>>> GetCouponsAsync(GetCouponsRequest request);
        Task<APIResponse<GetCouponsResponse>> GetCouponByIdAsync(Guid id);
        Task<APIResponse<Guid>> CreateCouponAsync(CreateCouponRequest request);
        Task<APIResponse<bool>> UpdateCouponAsync(Guid id, UpdateCouponRequest request);
    }
}
