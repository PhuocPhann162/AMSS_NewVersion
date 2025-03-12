using AMSS.Models.Commodities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.CartItems
{
    public partial class CartItem : BaseModel<Guid>
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid CommodityId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid ShoppingCartId { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
