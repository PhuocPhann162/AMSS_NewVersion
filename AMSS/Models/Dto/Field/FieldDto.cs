using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.Location;
using AMSS.Models.Dto.Farm;
using AMSS.Models.Dto.Polygon;
using AMSS.Models.Dto.FieldCrop;

namespace AMSS.Models.Dto.Field
{
    public class FieldDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public double? Area { get; set; }

        public string? Status { get; set; }

        public int? FarmId { get; set; }
        public int? LocationId { get; set; }
        public int? PolygonAppId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public LocationDto Location { get; set; }
        public FarmDto Farm { get; set; }
        public IEnumerable<FieldCropDto> FieldCrops { get; set; }
        public PolygonDto PolygonApp { get; set; }
        public SoilQuality SoilQuality { get; set; }
    }
}
