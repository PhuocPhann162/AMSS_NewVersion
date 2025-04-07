using AMSS.Aggregates;
using AMSS.Dto.Requests.Orders;
using AMSS.Enums;

namespace AMSS.Models.OrderHeaders
{
    public partial class OrderHeader : IAggregateRoot
    {
        public OrderHeader()
        {
            
        }

        public OrderHeader(CreateOrderRequest request, Guid userId)
        {
            ApplicationUserId = userId;
            PickupName = request.PickupName?.Trim();
            PickupEmail = request.PickupEmail?.Trim();
            PickupPhoneNumber = request.PickupPhoneNumber?.Trim();
            OrderTotal = request.OrderTotal;
            CouponCode = request.CouponCode;
            DiscountAmount = request.DiscountAmount;
            OrderDate = DateTime.Now;
            Status = OrderStatus.Pending;
            TotalItems = request.TotalItems;
            StripePaymentIntentID = request.StripePaymentIntentID;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateOrderRequest request, Guid userId)
        {
            ApplicationUserId = userId;
            PickupName = request.PickupName?.Trim();
            PickupEmail = request.PickupEmail?.Trim();
            PickupPhoneNumber = request.PickupPhoneNumber?.Trim();
            OrderTotal = request.OrderTotal;
            CouponCode = request.CouponCode;
            DiscountAmount = request.DiscountAmount;
            OrderDate = DateTime.Now;
            Status = OrderStatus.Pending;
            TotalItems = request.TotalItems;
            UpdatedAt = DateTime.Now;
        }
    }
}
