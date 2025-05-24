using AMSS.Dto.Responses.ShoppingCarts;

namespace AMSS.Dto.Responses.Payment
{
    public class MakePaymentResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? CouponCode { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }

        public decimal Discount { get; set; }
        public decimal CartTotal { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
    }
}
