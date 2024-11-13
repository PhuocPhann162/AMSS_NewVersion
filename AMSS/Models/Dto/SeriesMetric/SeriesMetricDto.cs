
using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Models.Dto.SeriesMetric
{
    public class SeriesMetricDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public IEnumerable<SocialMetricDto>? SocialMetrics { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
