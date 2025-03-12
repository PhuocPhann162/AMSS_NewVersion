using System.ComponentModel.DataAnnotations.Schema;
using AMSS.Models.Commodities;

namespace AMSS.Models.OrderDetails
{
    public partial class OrderDetail : BaseModel<Guid>
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid OrderHeaderId { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid CommodityId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ItemName { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
