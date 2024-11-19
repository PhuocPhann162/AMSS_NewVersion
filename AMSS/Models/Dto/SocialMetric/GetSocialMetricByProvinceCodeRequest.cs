using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Models.Dto.SocialMetric
{
    public class GetSocialMetricByProvinceCodeRequest
    {
        [Required(ErrorMessage = "Province Code is Required")]
        [JsonPropertyName("ProvinceCode")]
        public string ProvinceCode { get; set; }

        [Required(ErrorMessage = "Series Code is Required")]
        [JsonPropertyName("SeriesCode")]
        public string SeriesCode { get; set; }
    }
}
