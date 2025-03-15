using AMSS.Dto.CountryContinent;
using AMSS.Dto.SocialMetric;

namespace AMSS.Dto.Province
{
    public class ProvinceDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Guid CountryContinentId { get; set; }
        public CountryContinentDto CountryContinent { get; set; }
        public IEnumerable<SocialMetricDto> SocialMetrics { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
