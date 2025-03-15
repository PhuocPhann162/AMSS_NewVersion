using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class SocialMetric : BaseModel<Guid>
    {
        [ForeignKey("SeriesMetricId")]
        [ValidateNever]
        public Guid? SeriesMetricId { get; set; }

        [ForeignKey("ProvinceId")]
        [ValidateNever]
        public Guid? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual SeriesMetric SeriesMetric { get; set; }
        public virtual ICollection<SocialYear> SocialYears { get; set; }
    }
}
