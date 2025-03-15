using AMSS.Dto.Farm;
using AMSS.Dto.Field;
using AMSS.Dto.Position;

namespace AMSS.Dto.Polygon
{
    public class PolygonDto
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public int Type { get; set; }

        public FarmDto Farm { get; set; }

        public FieldDto Field { get; set; }

        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
