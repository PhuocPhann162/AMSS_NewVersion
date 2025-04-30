using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.Polygon
{
    public class PolygonApp : BaseModel<Guid>
    {
        [MaxLength(50)]
        public string Color { get; set; }

        [Range(0, 1)]
        public int Type { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
