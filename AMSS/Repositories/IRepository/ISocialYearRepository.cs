﻿using AMSS.Models;

namespace AMSS.Repositories.IRepository
{
    public interface ISocialYearRepository : IRepository<SocialYear>
    {
        Task<SocialYear> Update(SocialYear socialMetric);
    }
}
