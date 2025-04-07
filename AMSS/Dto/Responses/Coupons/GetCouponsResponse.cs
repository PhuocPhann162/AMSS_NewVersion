using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Coupons
{
    public class GetCouponsResponse
    {
        [JsonPropertyName("CouponId")]
        public Guid CouponId { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("MinAmount")]
        public decimal MinAmount { get; set; }

        [JsonPropertyName("Expiration")]
        public DateTime Expiration { get; set; }
        [JsonPropertyName("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
