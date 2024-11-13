using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Models.Dto.SocialYear
{
    public class SocialYearDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
        public SocialMetricDto? SocialMetric { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
