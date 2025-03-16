using AMSS.Dto.Requests.ShoppingCarts;
using AMSS.Dto.Responses.ShoppingCarts;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<APIResponse<GetShoppingCartResponse>> GetShoppingCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> AddOrUpdateItemInCartAsync(AddOrUpdateItemInCartRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> ApplyCouponAsync(ApplyCouponRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
