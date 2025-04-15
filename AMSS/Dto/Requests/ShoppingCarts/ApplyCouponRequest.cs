using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.ShoppingCarts
{
    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; }
    }
}
