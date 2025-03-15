using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Dto.Location;
using AMSS.Dto.Polygon;

namespace AMSS.Dto.Farm
{
    public class FarmDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Area { get; set; }
        [Required]
        public Guid LocationId { get; set; }

        public string OwnerName { get; set; }

        [Required]
        public Guid PolygonAppId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public LocationDto Location { get; set; }
        public PolygonDto PolygonApp { get; set; }

    }
}
