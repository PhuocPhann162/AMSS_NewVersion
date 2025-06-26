using AMSS.Data;
using AMSS.Entities.Commodities;
using AMSS.Models.Commodities;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Repositories
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        private readonly ApplicationDbContext _db;
        public CommodityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Commodity> GetCommodityOriginAsync(Guid commodityId)
        {
            return await _db.Commodities
                .Where(x => x.Id == commodityId)
                .Include(x => x.Supplier)
                .Include(x => x.Crop)
                    .ThenInclude(x => x.Supplier)
                .FirstOrDefaultAsync();
        }
    }
}
