using AMSS.Dto.Requests.Orders;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Orders;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Models.OrderHeaders;
using System.Net;
using AMSS.Models.OrderDetails;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using AMSS.Enums;
using AutoMapper;
using AMSS.Dto.Location;

namespace AMSS.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public OrderService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<APIResponse<PaginationResponse<GetOrdersResponse>>> GetOrdersAsync(GetOrdersRequest request, Guid userId)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id == userId.ToString());
            if (user is null)
            {
                return BuildErrorResponseMessage<PaginationResponse<GetOrdersResponse>>("User does not exist", HttpStatusCode.BadRequest);
            }
            var roles = await _userManager.GetRolesAsync(user);

            var sortExpressions = new List<SortExpression<OrderHeader>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<OrderHeader, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["PickupName"] = x => x.PickupName,
                ["OrderTotal"] = x => x.OrderTotal,
                ["OrderDate"] = x => x.OrderDate
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<OrderHeader>(sortField, request.OrderByDirection));
            }

            // filter
            Expression<Func<OrderHeader, bool>> filter;
            if (roles.Contains(Role.ADMIN.ToString()))
            {
                filter = x =>
                    (request.Statuses == null || request.Statuses.Count() == 0 || request.Statuses.Contains(x.Status)) &&
                    (string.IsNullOrEmpty(request.Search) || x.PickupName.Contains(request.Search) || x.PickupEmail.Contains(request.Search));
            }
            else
            {
                filter = x =>
                    (request.Statuses == null || request.Statuses.Count() == 0 || request.Statuses.Contains(x.Status)) &&
                    (string.IsNullOrEmpty(request.Search) || x.PickupName.Contains(request.Search) || x.PickupEmail.Contains(request.Search)) &&
                    x.ApplicationUserId == userId;
            }

            var orderHeadersPaginationResult = await _unitOfWork.OrderHeaderRepository.GetAsync(
                filter,
                request.CurrentPage,
                request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<GetOrdersResponse>(orderHeadersPaginationResult.CurrentPage, orderHeadersPaginationResult.Limit,
                            orderHeadersPaginationResult.TotalRow, orderHeadersPaginationResult.TotalPage)
            {
                Collection = orderHeadersPaginationResult.Data.Select(x => new GetOrdersResponse
                {
                    Id = x.Id,
                    PickupName = x.PickupName,
                    PickupEmail = x.PickupEmail,
                    PickupPhoneNumber = x.PickupPhoneNumber,
                    DiscountAmount = x.DiscountAmount,
                    OrderDate = x.OrderDate,
                    OrderTotal = x.OrderTotal,
                    Status = (int)x.Status,
                    TotalItems = x.TotalItems,
                })
            };
            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<GetOrderResponse>> GetOrderByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetOrderResponse>("Not valid ID order", HttpStatusCode.BadRequest);
            }

            var orderHeader = await _unitOfWork.OrderHeaderRepository.GetAsync(x => x.Id == id, includeProperties: "OrderDetails,OrderDetails.Commodity,Location");
            if (orderHeader == null)
            {
                return BuildErrorResponseMessage<GetOrderResponse>("Not found this order", HttpStatusCode.NotFound);
            }

            var response = new GetOrderResponse()
            {
                Id = orderHeader.Id,
                PickupName = orderHeader.PickupName,
                PickupEmail = orderHeader.PickupEmail,
                PickupPhoneNumber = orderHeader.PickupPhoneNumber,
                DiscountAmount = orderHeader.DiscountAmount,
                CouponCode = orderHeader.CouponCode,
                OrderDate = orderHeader.OrderDate,
                OrderTotal = orderHeader.OrderTotal,
                Status = (int)orderHeader.Status,
                TotalItems = orderHeader.TotalItems,
                Location = _mapper.Map<LocationDto>(orderHeader.Location),
                OrderDetails = orderHeader.OrderDetails.Select(x => new OrderDetailDto
                {
                    OrderHeaderId = x.OrderHeaderId,
                    CommodityId = x.CommodityId,
                    Commodity = _mapper.Map<CommodityDto>(x.Commodity),
                    ItemName = x.ItemName,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
            };

            return BuildSuccessResponseMessage(response, "Get Order by ID successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<Guid>> CreateOrderAsync(CreateOrderRequest request, Guid userId)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId.ToString());
            if (user is null)
            {
                return BuildErrorResponseMessage<Guid>("User not found", HttpStatusCode.NotFound);
            }

            var location = await _unitOfWork.LocationRepository.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);

            var newOrder = new OrderHeader(request, userId, location.Id);
            await _unitOfWork.OrderHeaderRepository.AddAsync(newOrder);

            var newOrderDetails = request.OrderDetails.Select(x => new OrderDetail()
            {
                Id = Guid.NewGuid(),
                OrderHeaderId = newOrder.Id,
                CommodityId = x.CommodityId,
                Quantity = x.Quantity,
                ItemName = x.ItemName,
                Price = x.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            });
            await _unitOfWork.OrderDetailRepository.AddRangeAsync(newOrderDetails);

            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(newOrder.Id, "Order created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<bool>> UpdateOrderAsync(Guid id, UpdateOrderRequest request, Guid userId)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<bool>("Not valid ID Order", HttpStatusCode.BadRequest);
            }
            var orderHeader = await _unitOfWork.OrderHeaderRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (orderHeader is null)
            {
                return BuildErrorResponseMessage<bool>("Not found this Order", HttpStatusCode.NotFound);
            }
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(userId.ToString());
            if(currentUser.Role is not Role.ADMIN)
            {
                return BuildErrorResponseMessage<bool>("You cannot access this Order", HttpStatusCode.BadRequest);
            }
            orderHeader.Update(request);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Order updated successfully", HttpStatusCode.OK);
        }
    }
}
