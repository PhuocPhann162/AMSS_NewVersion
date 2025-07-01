using AMSS.Data;
using AMSS.Entities.CareLogs;

namespace AMSS.Repositories
{
    public class CareLogRepository : Repository<CareLog>, ICareLogRepository
    {
        private readonly ApplicationDbContext _db;
        public CareLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
