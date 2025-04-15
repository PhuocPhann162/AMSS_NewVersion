﻿using AMSS.Entities;
using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Commodities
{
    public class GetCommodityResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SpecialTag { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public CommodityStatus Status { get; set; }

        public string CropName { get; set; }

    }
}
