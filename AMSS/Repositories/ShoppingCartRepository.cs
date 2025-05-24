using AMSS.Data;
using AMSS.Entities.ShoppingCarts;
using AMSS.Models.ShoppingCarts;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(Guid userId)
        {
            return await dbSet
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Commodity)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
