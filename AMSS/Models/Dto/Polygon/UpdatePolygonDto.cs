using AMSS.Models.Polygon;

namespace AMSS.Models.Dto.Polygon
{
    public class UpdatePolygonDto
    {
        public int Id { get; set; }
        public IEnumerable<Position> Positions { get; set; }
    }
}
