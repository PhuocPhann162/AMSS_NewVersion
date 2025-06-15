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
using System.Linq.Expressions;
using System.ComponentModel;

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

            var sortFieldMap = new Dictionary<string, Expression<Func<Coupon, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Title"] = x => x.Title,
                ["DiscountAmount"] = x => x.DiscountAmount,
                ["Expiration"] = x => x.Expiration
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Coupon>(sortField, request.OrderByDirection));
            } 
            else
            {
                sortExpressions.Add(new SortExpression<Coupon>(x => x.CreatedAt, ListSortDirection.Descending));
            }

            Expression<Func<Coupon, bool>> filter = x =>
                   (string.IsNullOrEmpty(request.Search) || x.Title.Contains(request.Search) || x.Code.Contains(request.Search));

            var couponsPaginationResult = await _unitOfWork.CouponRepository.GetAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray()
            );
            var response = new PaginationResponse<GetCouponsResponse>(couponsPaginationResult.CurrentPage, couponsPaginationResult.Limit,
                            couponsPaginationResult.TotalRow, couponsPaginationResult.TotalPage)
            {
                Collection = couponsPaginationResult.Data.Select(x => new GetCouponsResponse
                {
                    Id = x.Id, 
                    Title = x.Title,
                    Description = x.Description,
                    Code = x.Code, 
                    DiscountAmount = x.DiscountAmount,
                    MinAmount = x.MinAmount, 
                    Expiration = x.Expiration, 
                    CreatedAt = x.CreatedAt
                })
            };
            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<GetCouponsResponse>> GetCouponByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetCouponsResponse>("Not valid ID coupon", HttpStatusCode.BadRequest);
            }

            var coupon = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (coupon == null)
            {
                return BuildErrorResponseMessage<GetCouponsResponse>("Not found this coupon", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetCouponsResponse>(coupon);

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
