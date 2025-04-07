﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class SocialYear : BaseModel<Guid>
    {
        [ForeignKey("SocialMetricId")]
        [ValidateNever]
        public Guid? SocialMetricId { get; set; }

        public int Year { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        public virtual SocialMetric SocialMetric { get; set; }
    }
}
