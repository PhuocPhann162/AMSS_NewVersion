using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface ISocialMetricRepository : IRepository<SocialMetric>
    {
        Task<SocialMetric> Update(SocialMetric socialMetric);
    }
}
