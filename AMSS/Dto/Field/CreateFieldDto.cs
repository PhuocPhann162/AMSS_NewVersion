using AMSS.Dto.Location;
using AMSS.Dto.Polygon;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Field
{
    public class CreateFieldDto
    {
        [Required(ErrorMessage = "Field name is required.")]
        [MaxLength(255, ErrorMessage = "Field name cannot exceed 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Area is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Area must be a positive double.")]
        public double Area { get; set; }

        [Required]
        public Guid FarmId { get; set; }

        public CreateLocationDto Location { get; set; }
        public CreatePolygonDto Polygon { get; set; }
    }

    public class CreateGrowLocationDto
    {
        [Required(ErrorMessage = "Field name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Internal ID is required.")]
        [StringLength(50)]
        public string InternalId { get; set; }

        [Required(ErrorMessage = "Location type is required.")]
        [StringLength(20)]
        public string LocationType { get; set; } // Field, Greenhouse, Garden

        [Required(ErrorMessage = "Planting format is required.")]
        [StringLength(20)]
        public string PlantingFormat { get; set; } // beds, cover, row, other

        public int? NumberOfBeds { get; set; }

        public float? BedLength { get; set; }

        public float? BedWidth { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50)]
        public string Status { get; set; } // Idle, Planted, Needs Care, etc.

        [StringLength(20)]
        public string LightProfile { get; set; } // Full Sun, Partial Sun, etc.

        public int? GrazingRestDays { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
