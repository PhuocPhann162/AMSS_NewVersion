
using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Farm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Area { get; set; }

        public string? OwnerName { get; set; }

        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public virtual Location Location { get; set; }

        [Required]
        public int PolygonAppId { get; set; }
        public virtual PolygonApp PolygonApp { get; set; }

        public virtual IEnumerable<Field> Fields { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
