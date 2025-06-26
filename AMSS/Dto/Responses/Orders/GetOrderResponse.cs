using AMSS.Dto.Location;
using AMSS.Enums;
using AMSS.Models.Commodities;

namespace AMSS.Dto.Responses.Orders
{
    public class GetOrderResponse
    {
        public Guid Id { get; set; }
        public string PickupName { get; set; }

        public string PickupPhoneNumber { get; set; }

        public string PickupEmail { get; set; }

        public decimal OrderTotal { get; set; }

        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public int Status { get; set; }

        public int TotalItems { get; set; }

        public LocationDto Location { get; set; }

        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderDetailDto
    {
        public Guid OrderHeaderId { get; set; }

        public Guid CommodityId { get; set; }

        public int Quantity { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public CommodityDto Commodity { get; set; }
    }

    public class CommodityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public CommodityStatus Status { get; set; }

        public string Image { get; set; }
    }
}
