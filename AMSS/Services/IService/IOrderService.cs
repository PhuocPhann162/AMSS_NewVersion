using AMSS.Dto.Requests.Orders;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Orders;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IOrderService
    {
        Task<APIResponse<PaginationResponse<GetOrdersResponse>>>GetOrdersAsync(GetOrdersRequest request);
        Task<APIResponse<GetOrderResponse>>GetOrderByIdAsync(Guid id);
        Task<APIResponse<Guid>>CreateOrderAsync(CreateOrderRequest request);
        Task<APIResponse<bool>>UpdateOrderAsync(Guid id, UpdateOrderRequest request);
    }
}
