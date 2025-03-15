using AMSS.Dto.Polygon;

namespace AMSS.Dto.Position
{
    public class PositionDto
    {
        public Guid Id { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }

        public Guid PolygonAppId { get; set; }
        public PolygonDto PolygonApp { get; set; }
    }
}
