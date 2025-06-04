using AMSS.Dto.Requests.ShoppingCarts;
using AMSS.Dto.Responses.ShoppingCarts;
using AMSS.Entities;
using AMSS.Models.CartItems;
using AMSS.Models.ShoppingCarts;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using System.Net;

namespace AMSS.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<APIResponse<GetShoppingCartResponse>> GetShoppingCartAsync(Guid userId)
        {
            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetAsync(u => u.UserId == userId, includeProperties: "CartItems,CartItems.Commodity"); ;

            if (shoppingCart is null)
            {
                return BuildErrorResponseMessage<GetShoppingCartResponse>("Shopping cart is not existed", HttpStatusCode.NotFound);
            }

            if (shoppingCart.CartItems != null && shoppingCart.CartItems.Count > 0)
            {
                shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.Commodity.Price);
            }

            if (!string.IsNullOrEmpty(shoppingCart.CouponCode))
            {
                var coupon = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(u => u.Code == shoppingCart.CouponCode);
                if (coupon != null && shoppingCart.CartTotal > coupon.MinAmount)
                {
                    shoppingCart.CartTotal -= coupon.DiscountAmount;
                    shoppingCart.Discount = coupon.DiscountAmount;
                }
            }

            var response = new GetShoppingCartResponse()
            {
                UserId = shoppingCart.UserId,
                CouponCode = shoppingCart.CouponCode,
                Discount = shoppingCart.Discount,
                CartTotal = shoppingCart.CartTotal,
                StripePaymentIntentId = shoppingCart.StripePaymentIntentId,
                ClientSecret = shoppingCart.ClientSecret,
                CartItems = shoppingCart.CartItems != null 
                ? shoppingCart.CartItems.Select(ci => new CartItemDto
                {
                    Id = ci.Id,
                    Quantity = ci.Quantity,
                    CommodityId = ci.CommodityId,
                    Price = ci.Commodity?.Price ?? 0,
                    CommodityName = ci.Commodity?.Name,
                    CommodityImage = ci.Commodity?.Image,
                    CommodityCategory = (int)(ci.Commodity?.Category ?? 0)
                }).ToList()
                : new List<CartItemDto>()
            };


            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<bool>> AddOrUpdateItemInCartAsync(AddOrUpdateItemInCartRequest request, Guid userId)
        {
            // Shopping cart will have one entry per user id, even if a user has many items in cart.
            // Cart items will have all the items in shopping cart for a user. 
            // updateQuantityBy will have count by with an items quantity needs to be updated.
            // if it is -1 that means we have lower a count if it is 5 it means we have to add 5 count to existing count.
            // if updateQuantityBy by is 0, item will be removed.

            // when a user adds a new item to a new shopping cart for the first time 
            // when a user adds a new item to an existing shopping cart (basically user has other items in cart) 
            // when a user updates an existing item count 
            // when a user removes an existing item

            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetAsync(u => u.UserId == userId, includeProperties: "CartItems");
            var commodity = await _unitOfWork.CommodityRepository.FirstOrDefaultAsync(u => u.Id == request.CommodityId);
            if (commodity == null)
            {
                return BuildErrorResponseMessage<bool>("Commodity is not existed", HttpStatusCode.NotFound);
            }
            if (shoppingCart == null && request.UpdateQuantityBy > 0)
            {
                // create a shopping cart && add cartItem
                ShoppingCart newCart = new() { UserId = userId, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
                await _unitOfWork.ShoppingCartRepository.AddAsync(newCart);

                CartItem newCartItem = new()
                {
                    CommodityId = request.CommodityId,
                    Quantity = request.UpdateQuantityBy,
                    ShoppingCartId = newCart.Id,
                    CreatedAt = DateTime.Now    
                };
                await _unitOfWork.CartItemRepository.AddAsync(newCartItem);
            }
            else
            {
                // shopping cart exists 
                var cartItemInCart = shoppingCart.CartItems.FirstOrDefault(u => u.CommodityId == request.CommodityId);
                if (cartItemInCart == null)
                {
                    // item does not exist in shoppingCart
                    CartItem newCartItem = new()
                    {
                        CommodityId = request.CommodityId,
                        Quantity = request.UpdateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        CreatedAt = DateTime.Now,
                    };
                    await _unitOfWork.CartItemRepository.AddAsync(newCartItem);
                }
                else
                {
                    // item already exist in the cart and we have to update quantity 
                    if (request.UpdateQuantityBy <= 0)
                    {
                        // remove cart item from cart and if it is the only item then remove cart 
                        await _unitOfWork.CartItemRepository.RemoveAsync(cartItemInCart);
                        if (shoppingCart.CartItems.Count() == 0)
                        {
                            shoppingCart.CartTotal = 0;
                            await _unitOfWork.ShoppingCartRepository.RemoveAsync(shoppingCart);
                        }
                    }
                    else
                    {
                        cartItemInCart.Quantity = request.UpdateQuantityBy;
                    }
                }
            }
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true);
        }

        public async Task<APIResponse<bool>> ApplyCouponAsync(ApplyCouponRequest request, Guid userId)
        {
            var shoppingCart = await _unitOfWork.ShoppingCartRepository.FirstOrDefaultAsync(u => u.UserId == userId);
            if (shoppingCart is null)
            {
                return BuildErrorResponseMessage<bool>("Shopping cart is not existed", HttpStatusCode.NotFound);
            }
            if (!string.IsNullOrEmpty(shoppingCart.CouponCode))
            {
                shoppingCart.CouponCode = "";
            }
            else
            {
                shoppingCart.CouponCode = request.CouponCode;
            }
            shoppingCart.Update();
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true);
        }
    }
}
