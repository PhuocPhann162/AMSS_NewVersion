using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location> Update(Location location);
    }
}
