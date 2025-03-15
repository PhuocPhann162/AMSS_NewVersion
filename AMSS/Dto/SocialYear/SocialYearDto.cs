using AMSS.Dto.SocialMetric;

namespace AMSS.Dto.SocialYear
{
    public class SocialYearDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
        public SocialMetricDto SocialMetric { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
