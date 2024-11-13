using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Models
{
    public class SocialYear : BaseModel<Guid>
    {
        [Required]
        [ForeignKey("SocialMetricId")]
        [ValidateNever]
        public Guid? SocialMetricId { get; set; }

        public int Year { get; set; }
        public decimal Value { get; set; }

        public virtual SocialMetric SocialMetric { get; set; } = null!;
    }
}
