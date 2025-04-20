using AMSS.Entities.Locations;
using AMSS.Entities.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Farm : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "float")]
        public double Area { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string OwnerName { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? PolygonAppId { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? LocationId { get; set; }

        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Location Location { get; set; }
        public virtual PolygonApp PolygonApp { get; set; }

        public virtual ICollection<Field> Fields { get; set; } 
    }
}
