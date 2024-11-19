using AMSS.Models.Dto.CountryContinent;
using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Models.Dto.Province
{
    public class ProvinceDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? CountryCode { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public Guid? CountryContinentId { get; set; }
        public CountryContinentDto? CountryContinent { get; set; }
        public IEnumerable<SocialMetricDto>? SocialMetrics { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
