using AMSS.Entities.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Field : BaseModel<Guid>
    {
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public double Area { get; set; } = 0;

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }


        public Guid? FarmId { get; set; }
        [ForeignKey("FarmId")]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Farm Farm { get; set; }

        public Guid? LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Location Location { get; set; }

        public Guid? PolygonAppId { get; set; }
        public virtual PolygonApp PolygonApp { get; set; }
        public virtual SoilQuality SoilQuality { get; set; }
        public virtual ICollection<FieldCrop> FieldCrops { get; set; }
    }
}
