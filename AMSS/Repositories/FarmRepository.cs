using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class FarmRepository : Repository<Farm>, IFarmRepository
    {
        private readonly ApplicationDbContext _db;
        public FarmRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Farm> Update(Farm farm)
        {
            farm.UpdatedAt = DateTime.Now;
            _db.Farms.Update(farm);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
