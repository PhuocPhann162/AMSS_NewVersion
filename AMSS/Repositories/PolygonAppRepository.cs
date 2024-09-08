using AMSS.Data;
using AMSS.Models.Polygon;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class PolygonAppRepository : Repository<PolygonApp>, IPolygonAppRepository
    {
        private readonly ApplicationDbContext _db;
        public PolygonAppRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<PolygonApp> Update(PolygonApp polygonApp)
        {
            _db.PolygonApps.Update(polygonApp);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
