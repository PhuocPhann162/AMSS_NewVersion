﻿using AMSS.Entities.Polygon;

namespace AMSS.Repositories.IRepository
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<Position> Update(Position position);
    }
}
