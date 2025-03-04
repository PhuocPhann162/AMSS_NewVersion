using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.Polygon;

namespace AMSS.Models.Dto.Position
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
