using AMSS.Entities;
using AMSS.Models.CartItems;
using AMSS.Models.Commodities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.ShoppingCarts
{
    public partial class ShoppingCart : BaseModel<Guid>
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? CouponCode { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Discount { get; set; }
        [NotMapped]
        [Column(TypeName = "decimal(18,6)")]
        public decimal CartTotal { get; set; }
        [NotMapped]
        public string StripePaymentIntentId { get; set; }
        [NotMapped]
        public string ClientSecret { get; set; }
    }
}
