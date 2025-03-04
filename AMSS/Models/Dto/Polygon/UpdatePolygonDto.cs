using AMSS.Models.Dto.Position;
using AMSS.Models.Polygon;

namespace AMSS.Models.Dto.Polygon
{
    public class UpdatePolygonDto
    {
        public Guid Id { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
