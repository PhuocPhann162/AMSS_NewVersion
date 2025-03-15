using AMSS.Data;
using AMSS.Entities.Commodities;
using AMSS.Models.Commodities;

namespace AMSS.Repositories
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        public CommodityRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
