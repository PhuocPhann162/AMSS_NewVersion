using AMSS.Dto.Requests.Orders;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Orders;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<APIResponse<Guid>> CreateOrderAsync(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<GetOrderResponse>> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<PaginationResponse<GetOrdersResponse>>> GetOrdersAsync(GetOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> UpdateOrderAsync(Guid id, UpdateOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
