using AMSS.Dto.Requests.Orders;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Orders;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Models.OrderHeaders;
using System.Net;

namespace AMSS.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<PaginationResponse<GetOrdersResponse>>> GetOrdersAsync(GetOrdersRequest request, Guid userId)
        {
            var sortExpressions = new List<SortExpression<OrderHeader>>();

            if (!string.IsNullOrEmpty(request.OrderBy) &&
                string.Equals(request.OrderBy, "CreatedAt", StringComparison.OrdinalIgnoreCase))
            {
                var sortExpression = new SortExpression<OrderHeader>(p => p.CreatedAt, request.OrderByDirection);
                sortExpressions.Add(sortExpression);
            }

            var orderHeadersPaginationResult = await _unitOfWork.OrderHeaderRepository.GetAsync(x => x.ApplicationUserId == userId, request.CurrentPage, request.Limit, sortExpressions.ToArray());
            var response = new PaginationResponse<GetOrdersResponse>(orderHeadersPaginationResult.CurrentPage, orderHeadersPaginationResult.Limit,
                            orderHeadersPaginationResult.TotalRow, orderHeadersPaginationResult.TotalPage)
            {
                Collection = orderHeadersPaginationResult.Data.Select(x => new GetOrdersResponse
                {
                    PickupName = x.PickupName,
                    PickupEmail = x.PickupEmail,    
                    PickupPhoneNumber = x.PickupPhoneNumber,
                    DiscountAmount = x.DiscountAmount,
                    OrderDate = x.OrderDate,
                    OrderTotal = x.OrderTotal,
                    Status = x.Status,
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

            var orderHeader = await _unitOfWork.OrderHeaderRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (orderHeader == null)
            {
                return BuildErrorResponseMessage<GetOrderResponse>("Not found this order", HttpStatusCode.NotFound);
            }

            var response = new GetOrderResponse()
            {
                PickupName = orderHeader.PickupName,
                PickupEmail = orderHeader.PickupEmail,
                PickupPhoneNumber = orderHeader.PickupPhoneNumber,
                DiscountAmount = orderHeader.DiscountAmount,
                OrderDate = orderHeader.OrderDate,
                OrderTotal = orderHeader.OrderTotal,
                Status = orderHeader.Status,
                TotalItems = orderHeader.TotalItems,
            };

            return BuildSuccessResponseMessage(response, "Get Order by ID successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<Guid>> CreateOrderAsync(CreateOrderRequest request, Guid userId)
        {
            var newOrder = new OrderHeader(request, userId);
            await _unitOfWork.OrderHeaderRepository.CreateAsync(newOrder);
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
            if (orderHeader == null)
            {
                return BuildErrorResponseMessage<bool>("Not found this Order", HttpStatusCode.NotFound);
            }
            orderHeader.Update(request, userId);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Order updated successfully", HttpStatusCode.OK);
        }
    }
}
