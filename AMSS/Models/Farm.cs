
using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Farm : BaseModel<Guid>
    {
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public double Area { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string OwnerName { get; set; }


        public Guid LocationId { get; set; } 
        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Location Location { get; set; } 

        public Guid? PolygonAppId { get; set; } 
        public virtual PolygonApp PolygonApp { get; set; } 

        public virtual ICollection<Field> Fields { get; set; } 
    }
}
