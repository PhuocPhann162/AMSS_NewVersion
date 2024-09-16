
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
        public string? Name { get; set; }
        public double? Area { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? OwnerName { get; set; }


        public Guid? LocationId { get; set; } = Guid.Empty;
        [ForeignKey("LocationId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Location Location { get; set; } = null!;

        public Guid? PolygonAppId { get; set; } = Guid.Empty;
        public virtual PolygonApp PolygonApp { get; set; } = null!;

        public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
