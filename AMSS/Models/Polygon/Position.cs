using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Polygon
{
    public class Position
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public float Lat { get; set; }
        public float lng { get; set; }

        public int? PolygonAppId { get; set; }
        [ForeignKey("PolygonAppId")]
        [ValidateNever]
        public PolygonApp PolygonApp { get; set; }

    }
}
