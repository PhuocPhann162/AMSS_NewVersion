﻿using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface ISeriesMetricRepository : IRepository<SeriesMetric>
    {
        Task<SeriesMetric> Update(SeriesMetric seriesMetric);
    }
}
