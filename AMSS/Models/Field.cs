using AMSS.Models.Dto.Farm;
using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;

        public double? Area { get; set; }

        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Guid? FarmId { get; set; }
        [ForeignKey("FarmId")]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Farm Farm { get; set; } = null!;

        public Guid? LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Location Location { get; set; } = null!;

        public Guid? PolygonAppId { get; set; } 
        public virtual PolygonApp PolygonApp { get; set; } = null!;
        public virtual SoilQuality SoilQuality { get; set; } = new();
        public virtual ICollection<FieldCrop> FieldCrops { get; set; } = new List<FieldCrop>();
    }
}
