using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Coupons
{
    public class UpdateCouponRequest
    {
        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("MinAmount")]
        public decimal MinAmount { get; set; }

        [JsonPropertyName("Expiration")]
        public DateTime Expiration { get; set; }
    }
}
