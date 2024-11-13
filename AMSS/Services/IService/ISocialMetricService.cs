using AMSS.Models;
using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Services.IService
{
    public interface ISocialMetricService 
    {
        Task<APIResponse<IEnumerable<SocialMetricDto>>> GetSocialMetricsByCountryCodeAsync(string countryCode);
        Task<APIResponse<bool>> ImportSocialMetricAsync(CreateSocialMetricDto createSocialMetricDto);
    }
}
