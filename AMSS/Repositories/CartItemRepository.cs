using AMSS.Data;
using AMSS.Entities.CartItems;
using AMSS.Models.CartItems;

namespace AMSS.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
