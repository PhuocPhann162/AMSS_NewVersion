using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.Farm;

namespace AMSS.Models.Dto.Polygon
{
    public class CreatePolygonDto
    {
        public string? Color { get; set; }

        public int? Type { get; set; }

        public IEnumerable<Position> Positions { get; set; }
    }
}
