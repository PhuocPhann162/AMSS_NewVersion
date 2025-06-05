using AMSS.Enums;

namespace AMSS.Dto.Requests.Orders
{
    public class GetOrdersRequest : PaginationRequest
    {
        public IEnumerable<OrderStatus> Statuses { get; set; }
    }
}
