using AMSS.Models;

namespace AMSS.Repositories.IRepository
{
    public interface ISeriesMetricRepository : IRepository<SeriesMetric>
    {
        Task<SeriesMetric> Update(SeriesMetric seriesMetric);
    }
}
