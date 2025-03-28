﻿using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface IFarmRepository : IRepository<Farm>
    {
        Task<Farm> Update(Farm farm);
    }
}
