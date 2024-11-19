using AMSS.Models.Dto.Province;
using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Models.Dto.CountryContinent
{
    public class CountryContinentDto
    {
        public Guid Id { get; set; }
        public float Co2Rate { get; set; }
        public string? ContinentCode { get; set; }
        public string? ContinentName { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public  IEnumerable<ProvinceDto>? Provinces { get; set; } 

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
