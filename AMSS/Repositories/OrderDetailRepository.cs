using AMSS.Data;
using AMSS.Models.OrderDetails;

namespace AMSS.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext db) : base(db)  
        {
            
        }
    }
}
