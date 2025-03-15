using AMSS.Dto.Location;
using AMSS.Dto.Position;

namespace AMSS.Dto.Field
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
