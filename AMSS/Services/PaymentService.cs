﻿using AMSS.Dto.Responses.Payment;
using AMSS.Dto.Responses.ShoppingCarts;
using AMSS.Entities;
using AMSS.Infrastructures.Configurations;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using Microsoft.Extensions.Options;
using Stripe;
using System.Net;

namespace AMSS.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StripePaymentConfiguration _stripeConfiguration;
        public PaymentService(IUnitOfWork unitOfWork, IOptionsMonitor<StripePaymentConfiguration> stripeConfiguration)
        {
            _unitOfWork = unitOfWork;
            _stripeConfiguration = stripeConfiguration.CurrentValue;
        }

        public async Task<APIResponse<MakePaymentResponse>> MakePaymentAsync(Guid userId)
        {
            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
            if (shoppingCart is null || shoppingCart.CartItems is null || shoppingCart.CartItems.Count() == 0) 
            {
                return BuildErrorResponseMessage<MakePaymentResponse>("Not found shopping cart with userID: " + userId, HttpStatusCode.NotFound);
            }

            var userCartItems = shoppingCart.CartItems.Select(x => new CartItemDto()
            {
                Id = x.Id,
                Quantity = x.Quantity,
                CommodityId = x.CommodityId, 
                CommodityName = x.Commodity.Name, 
                CommodityImage = x.Commodity.Image,
                CommodityCategory = (int)x.Commodity.Category, 
                Price = x.Commodity.Price
            });

            #region Create Payment Intent
            StripeConfiguration.ApiKey = _stripeConfiguration.SecretKey;
            shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.Commodity.Price);


            if (!string.IsNullOrEmpty(shoppingCart.CouponCode))
            {
                var coupon = await _unitOfWork.CouponRepository.FirstOrDefaultAsync(u => u.Code == shoppingCart.CouponCode);
                if (coupon != null && shoppingCart.CartTotal > coupon.MinAmount)
                {
                    var discountAmount = shoppingCart.CartTotal * coupon.DiscountAmount / 100;
                    shoppingCart.CartTotal -= discountAmount;
                    shoppingCart.Discount = discountAmount;
                }
            }
            else
            {
                shoppingCart.Discount = 0;
            }

            PaymentIntentCreateOptions options = new()
            {
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };
            PaymentIntentService service = new();
            PaymentIntent response = service.Create(options);

            shoppingCart.StripePaymentIntentId = response.Id;
            shoppingCart.ClientSecret = response.ClientSecret;
            #endregion

            var responsePayment = new MakePaymentResponse()
            {
                Id = shoppingCart.Id, 
                UserId = shoppingCart.UserId, 
                CouponCode = shoppingCart.CouponCode,
                Discount = shoppingCart.Discount, 
                CartTotal = shoppingCart.CartTotal, 
                StripePaymentIntentId = shoppingCart.StripePaymentIntentId,
                ClientSecret = shoppingCart.ClientSecret,
                CartItems = userCartItems
            };

            return BuildSuccessResponseMessage(responsePayment);
        }
    }
}
