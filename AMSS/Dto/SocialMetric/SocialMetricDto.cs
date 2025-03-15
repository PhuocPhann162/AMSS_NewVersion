using AMSS.Dto.Province;
using AMSS.Dto.SeriesMetric;
using AMSS.Dto.SocialYear;

namespace AMSS.Dto.SocialMetric
{
    public class SocialMetricDto
    {
        public Guid Id { get; set; }
        public Guid SeriesMetricId { get; set; }
        public Guid ProvinceId { get; set; }
        public ProvinceDto Province { get; set; }
        public SeriesMetricDto SeriesMetric { get; set; }
        public IEnumerable<SocialYearDto> SocialYears { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
