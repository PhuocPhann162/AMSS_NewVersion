using AMSS.Data;
using AMSS.Entities.ShoppingCarts;
using AMSS.Models.ShoppingCarts;

namespace AMSS.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
