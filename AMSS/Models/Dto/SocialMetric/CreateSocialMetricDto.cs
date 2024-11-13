using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Models.Dto.SocialMetric
{
    public class CreateSocialMetricDto
    {
        [Required(ErrorMessage = "Please select file to upload")]
        [JsonPropertyName("File")]
        public IFormFile File { get; set; }

    }
}
