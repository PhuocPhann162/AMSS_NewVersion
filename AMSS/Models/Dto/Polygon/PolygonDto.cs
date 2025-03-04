using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.Farm;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.Position;

namespace AMSS.Models.Dto.Polygon
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
