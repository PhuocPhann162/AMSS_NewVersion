using AMSS.Entities;
using AMSS.Enums;
using AMSS.Models.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Commodities
{
    public partial class Commodity : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SpecialTag { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public double Price { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Image { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        public CommodityStatus Status { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid SupplierId { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid CropId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Crop Crop { get; set; }

    }
}
