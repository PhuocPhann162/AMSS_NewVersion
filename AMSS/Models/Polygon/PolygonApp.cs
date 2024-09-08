using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Polygon
{
    public class PolygonApp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Color { get; set; }
        public int? Type { get; set; }

        public virtual Farm Farm { get; set; }

        public virtual Field Field { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
