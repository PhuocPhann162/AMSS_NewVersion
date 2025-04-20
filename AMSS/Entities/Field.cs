using AMSS.Entities.Locations;
using AMSS.Entities.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Field : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "float")]
        public double Area { get; set; } = 0;

        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? FarmId { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? LocationId { get; set; }
        

        [Column(TypeName = "uniqueidentifier")]
        public Guid? PolygonAppId { get; set; }

        [ForeignKey("LocationId")]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Location Location { get; set; }

        [ForeignKey("FarmId")]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Farm Farm { get; set; }
        public virtual PolygonApp PolygonApp { get; set; }
        public virtual SoilQuality SoilQuality { get; set; }
        public virtual ICollection<FieldCrop> FieldCrops { get; set; }
    }
}
