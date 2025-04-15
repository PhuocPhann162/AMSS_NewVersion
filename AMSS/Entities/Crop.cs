using AMSS.Models.Commodities;
using AMSS.Models.Suppliers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Crop : BaseModel<Guid>
    {
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Icon { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Cycle { get; set; }

        public bool Edible { get; set; } = false;

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Soil { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Watering { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Maintenance { get; set; }

        public int HardinessZone { get; set; } = 0;

        public bool Indoor { get; set; } = false;

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Propagation { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string CareLevel { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string GrowthRate { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        public double CultivatedArea { get; set; } = 0;

        public DateTime? PlantedDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        public Guid? SupplierId { get; set; }

        public Guid? CropTypeId { get; set; }
        [ForeignKey("CropTypeId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual CropType CropType { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<FieldCrop> FieldCrops { get; set; }
        public virtual ICollection<Commodity> Commodities { get; set; } = new List<Commodity>();
    }
}
