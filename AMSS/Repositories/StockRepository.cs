using AMSS.Data;
using AMSS.Entities.Stocks;
using AMSS.Models.Stocks;

namespace AMSS.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
