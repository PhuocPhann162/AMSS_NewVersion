using AMSS.Dto.Requests.ShoppingCarts;
using AMSS.Dto.Responses.ShoppingCarts;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IShoppingCartService
    {
        Task<APIResponse<GetShoppingCartResponse>> GetShoppingCartAsync(Guid userId);
        Task<APIResponse<bool>> AddOrUpdateItemInCartAsync(AddOrUpdateItemInCartRequest request, Guid userId);
        Task<APIResponse<bool>> ApplyCouponAsync(ApplyCouponRequest request, Guid userId);
    }
}
