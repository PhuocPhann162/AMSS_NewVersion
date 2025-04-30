using AMSS.Dto.Requests.Coupons;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Coupons;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Models.Coupons;
using System.Net;
using AutoMapper;

namespace AMSS.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CouponService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponse<PaginationResponse<GetCouponsResponse>>> GetCouponsAsync(GetCouponsRequest request)
        {
            var sortExpressions = new List<SortExpression<Coupon>>();

            if (!string.IsNullOrEmpty(request.OrderBy) &&
                string.Equals(request.OrderBy, "CreatedAt", StringComparison.OrdinalIgnoreCase))
            {
                var sortExpression = new SortExpression<Coupon>(p => p.CreatedAt, request.OrderByDirection);
                sortExpressions.Add(sortExpression);
            }

            var couponsPaginationResult = await _unitOfWork.CouponRepository.GetAsync(null, request.CurrentPage, request.Limit, sortExpressions.ToArray());
            var response = new PaginationResponse<GetCouponsResponse>(couponsPaginationResult.CurrentPage, couponsPaginationResult.Limit,
                            couponsPaginationResult.TotalRow, couponsPaginationResult.TotalPage)
            {
                Collection = couponsPaginationResult.Data.Select(x => new GetCouponsResponse
                {
                    CouponId = x.Id, 
                    Code = x.Code, 
                    DiscountAmount = x.DiscountAmount,
                    MinAmount = x.MinAmount, 
                    Expiration = x.Expiration, 
                    CreatedAt = x.CreatedAt
                })
            };
            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<GetCouponResponse>> GetCouponByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetCouponResponse>("Not valid ID coupon", HttpStatusCode.BadRequest);
            }

            var coupon = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (coupon == null)
            {
                return BuildErrorResponseMessage<GetCouponResponse>("Not found this coupon", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetCouponResponse>(coupon);

            return BuildSuccessResponseMessage(response, "Get coupon by ID successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<Guid>> CreateCouponAsync(CreateCouponRequest request)
        {
            var couponWithCode = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(x => x.Code == request.Code);
            if(couponWithCode is not null)
            {
                return BuildErrorResponseMessage<Guid>("Coupon code was already existed", HttpStatusCode.Conflict);
            }
            var newCoupon = new Coupon(request);
            await _unitOfWork.CouponRepository.AddAsync(newCoupon);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(newCoupon.Id, "Coupon created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<bool>> UpdateCouponAsync(Guid id, UpdateCouponRequest request)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<bool>("Not valid ID coupon", HttpStatusCode.BadRequest);
            }
            var coupon = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (coupon == null)
            {
                return BuildErrorResponseMessage<bool>("Not found this coupon", HttpStatusCode.NotFound);
            }
            coupon.Update(request);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Coupon updated successfully", HttpStatusCode.OK);
        }
    }
}
