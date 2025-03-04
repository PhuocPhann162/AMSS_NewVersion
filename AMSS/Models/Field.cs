using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Field : BaseModel<Guid>
    {
        [Required]
        public string Name { get; set; } 
        public double Area { get; set; }
        public string Status { get; set; }
        

        public Guid FarmId { get; set; }
        [ForeignKey("FarmId")]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Farm Farm { get; set; }

        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Location Location { get; set; } 

        public Guid PolygonAppId { get; set; } 
        public virtual PolygonApp PolygonApp { get; set; } 
        public virtual SoilQuality SoilQuality { get; set; } = new();
        public virtual ICollection<FieldCrop> FieldCrops { get; set; } 
    }
}
