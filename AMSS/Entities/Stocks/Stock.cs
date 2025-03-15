using AMSS.Entities;
using AMSS.Models.Commodities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Stocks
{
    public partial class Stock : BaseModel<Guid>
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid CommodityId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string WarehouseLocation { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
