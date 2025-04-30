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
}
