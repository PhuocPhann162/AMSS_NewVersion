using AMSS.Data;
using AMSS.Models.OrderHeaders;

namespace AMSS.Repositories
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
