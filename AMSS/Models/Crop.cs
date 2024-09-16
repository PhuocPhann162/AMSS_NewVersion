using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Crop : BaseModel<Guid>
    {
        [Required]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Icon { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Cycle { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public bool? Edible { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Soil { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Watering { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Maintenance { get; set; }

        public int? HardinessZone { get; set; }

        public bool? Indoor { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Propogation { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? CareLevel { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? GrowthRate { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        public double? CultivatedArea { get; set; }

        public DateTime? PlantedDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        [Range(0, double.PositiveInfinity)]
        public int? Quantity { get; set; } = 0;

        public Guid? CropTypeId { get; set; }
        [ForeignKey("CropTypeId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual CropType CropType { get; set; } = null!;

        public virtual ICollection<FieldCrop> FieldCrops { get; set; } = new List<FieldCrop>();
    }
}
