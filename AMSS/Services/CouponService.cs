using AMSS.Dto.Requests.Coupons;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Coupons;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CouponService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<APIResponse<PaginationResponse<GetCouponsResponse>>> GetCouponsAsync(GetCouponsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<GetCouponResponse>> GetCouponByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<Guid>> CreateCouponAsync(CreateCouponRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> UpdateCouponAsync(Guid id, UpdateCouponRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
