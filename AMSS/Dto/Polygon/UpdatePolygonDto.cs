using AMSS.Dto.Position;

namespace AMSS.Dto.Polygon
{
    public class UpdatePolygonDto
    {
        public Guid Id { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
