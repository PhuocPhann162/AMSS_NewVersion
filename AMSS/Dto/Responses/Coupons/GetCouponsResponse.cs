using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Coupons
{
    public class GetCouponsResponse
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
