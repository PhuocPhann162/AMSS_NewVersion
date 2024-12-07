using AMSS.Models;
using AMSS.Models.Dto.SocialMetric;

namespace AMSS.Services.IService
{
    public interface ISocialMetricService 
    {
        Task<APIResponse<IEnumerable<SocialMetricDto>>> GetSocialMetricsByProvinceCode(GetSocialMetricByProvinceCodeRequest request);
        Task<APIResponse<bool>> ImportSocialMetricAsync(CreateSocialMetricDto createSocialMetricDto);
    }
}
