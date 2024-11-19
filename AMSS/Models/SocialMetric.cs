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
        [ForeignKey("ProvinceId")]
        [ValidateNever]
        public Guid? ProvinceId { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual SeriesMetric SeriesMetric { get; set; } = null!;
        public virtual ICollection<SocialYear> SocialYears { get; set; } = null!;
    }
}
