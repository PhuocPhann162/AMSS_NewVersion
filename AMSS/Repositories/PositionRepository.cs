using AMSS.Data;
using AMSS.Models.Polygon;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _db;
        public PositionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Position> Update(Position position)
        {
            _db.Positions.Update(position);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
