using AMSS.Data;
using AMSS.Entities;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class SocialMetricRepository : Repository<SocialMetric>, ISocialMetricRepository
    {
        private readonly ApplicationDbContext _db;
        public SocialMetricRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SocialMetric> Update(SocialMetric socialMetric)
        {
            socialMetric.UpdatedAt = DateTime.Now;
            _db.SocialMetrics.Update(socialMetric);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
