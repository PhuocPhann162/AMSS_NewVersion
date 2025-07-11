﻿using AMSS.Enums;

namespace AMSS.Dto.Responses.ShoppingCarts
{
    public class GetShoppingCartResponse
    {
        public Guid UserId { get; set; }
        public string CouponCode { get; set; }
        public decimal Discount { get; set; }
        public decimal CartTotal { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new();
    }

    public class CartItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string CommodityImage { get; set; }
        public string CommodityDescription { get; set; }
        public int CommodityCategory { get; set; }
        public decimal Price { get; set; }
    }
}
