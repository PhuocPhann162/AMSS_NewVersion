using AMSS.Data;
using AMSS.Entities;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class SeriesMetricRepository : Repository<SeriesMetric>, ISeriesMetricRepository
    {
        private readonly ApplicationDbContext _db;
        public SeriesMetricRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SeriesMetric> Update(SeriesMetric seriesMetric)
        {
            seriesMetric.UpdatedAt = DateTime.Now;
            _db.SeriesMetrics.Update(seriesMetric);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
