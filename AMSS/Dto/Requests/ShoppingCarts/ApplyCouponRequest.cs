using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.ShoppingCarts
{
    public class ApplyCouponRequest
    {
        [JsonPropertyName("CouponCode")]
        public string CouponCode { get; set; }
    }
}
