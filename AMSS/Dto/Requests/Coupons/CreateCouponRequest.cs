using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Coupons
{
    public class CreateCouponRequest
    {
        [Required(ErrorMessage = "Coupon code is required.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Coupon discount amount is required.")]
        public decimal DiscountAmount { get; set; }

        [Required(ErrorMessage = "Coupon min amount is required.")]
        public decimal MinAmount { get; set; }

        [Required(ErrorMessage = "Coupon expiration is required.")]
        public DateTime Expiration { get; set; }
    }
}
