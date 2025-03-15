using AMSS.Dto.SocialMetric;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ISocialMetricService 
    {
        Task<APIResponse<IEnumerable<SocialMetricDto>>> GetSocialMetricsByProvinceCode(GetSocialMetricByProvinceCodeRequest request);
        Task<APIResponse<bool>> ImportSocialMetricAsync(CreateSocialMetricDto createSocialMetricDto);
    }
}
