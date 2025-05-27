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

        public string InternalId { get; set; }

        public string PlantingFormat { get; set; }

        public string LocationType { get; set; }

        public string LightProfile { get; set; }

        public int GrazingRestDays { get; set; }

        public int NumberOfBeds { get; set; }

        public decimal? BedLength { get; set; }

        public decimal? BedWidth { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public LocationDto Location { get; set; }
        public FarmDto Farm { get; set; }
        public IEnumerable<FieldCropDto> FieldCrops { get; set; }
        public PolygonDto PolygonApp { get; set; }
        public SoilQualityDto SoilQuality { get; set; }
    }
}
