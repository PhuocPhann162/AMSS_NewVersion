using AMSS.Models.ShoppingCarts;
using AMSS.Repositories.IRepository;

namespace AMSS.Entities.ShoppingCarts
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetShoppingCartByUserIdAsync(Guid userId);
    }
}
