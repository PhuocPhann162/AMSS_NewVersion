using AMSS.Data;
using AMSS.Entities;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        private readonly ApplicationDbContext _db;
        public ProvinceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
