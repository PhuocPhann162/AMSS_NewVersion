using AMSS.Dto.Position;

namespace AMSS.Dto.Polygon
{
    public class CreatePolygonDto
    {
        public string Color { get; set; }
        public int Type { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
