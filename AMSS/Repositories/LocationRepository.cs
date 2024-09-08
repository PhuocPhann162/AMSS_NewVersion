using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Location> Update(Location location)
        {
            location.UpdatedAt = DateTime.Now;
            _db.Locations.Update(location);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
