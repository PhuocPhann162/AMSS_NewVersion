using AMSS.Entities.Locations;
using AMSS.Entities.Polygon;
using AMSS.Enums;
using Microsoft.EntityFrameworkCore;
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

        [Column(TypeName = "nvarchar(50)")]
        public string InternalId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PlantingFormat { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string LocationType { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string LightProfile { get; set; }

        [Column(TypeName = "int")]
        public int GrazingRestDays { get; set; }

        [Column(TypeName = "int")]
        public int NumberOfBeds { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BedLength { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BedWidth { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }

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
