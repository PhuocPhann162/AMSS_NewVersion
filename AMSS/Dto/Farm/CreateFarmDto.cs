using AMSS.Dto.Location;
using AMSS.Dto.Polygon;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Farm
{
    public class CreateFarmDto
    {
        [Required(ErrorMessage = "Farm name is required.")]
        [MaxLength(255, ErrorMessage = "Farm name cannot exceed 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Area is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Area must be a positive double.")]
        public double Area { get; set; }

        [Required(ErrorMessage = "Owner name is required.")]
        [MaxLength(255, ErrorMessage = "Owner name cannot exceed 255 characters.")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Owner id is required.")]
        public Guid OwnerId { get; set; }

        public CreateLocationDto Location { get; set; }
        public CreatePolygonDto Polygon { get; set; }
    }
}
