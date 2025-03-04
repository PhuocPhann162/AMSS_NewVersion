using AMSS.Models.Dto.Location;
using AMSS.Models.Dto.Position;
using AMSS.Models.Polygon;

namespace AMSS.Models.Dto.Field
{
    public class UpdateFieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Area { get; set; }
        public LocationDto Location { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
