using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Dto.Farm;
using AMSS.Dto.FieldCrop;
using AMSS.Dto.Location;
using AMSS.Dto.Polygon;
using AMSS.Dto.SoilQuality;

namespace AMSS.Dto.Field
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Area { get; set; }

        public string Status { get; set; }

        public Guid FarmId { get; set; }
        public Guid LocationId { get; set; }
        public Guid PolygonAppId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public LocationDto Location { get; set; }
        public FarmDto Farm { get; set; }
        public IEnumerable<FieldCropDto> FieldCrops { get; set; }
        public PolygonDto PolygonApp { get; set; }
        public SoilQualityDto SoilQuality { get; set; }
    }
}
