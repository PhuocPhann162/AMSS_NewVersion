﻿using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Coupons
{
    public class UpdateCouponRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal MinAmount { get; set; }

        public DateTime Expiration { get; set; }
    }
}
