using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class SocialMetric : BaseModel<Guid>
    {
        [Required]
        [ForeignKey("SeriesMetricId")]
        [ValidateNever]
        public Guid? SeriesMetricId { get; set; }

        [Required]
        [ForeignKey("CountryContinentId")]
        [ValidateNever]
        public Guid? CountryContinentId { get; set; }

        public virtual CountryContinent CountryContinent { get; set; } = null!;
        public virtual SeriesMetric SeriesMetric { get; set; } = null!;

        public virtual ICollection<SocialYear> SocialYears { get; set; } = null!;
    }
}
