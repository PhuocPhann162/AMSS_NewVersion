using AMSS.Dto.Crop;
using AMSS.Dto.Suppliers;
using AMSS.Entities;
using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Commodities
{
    public class GetCommodityResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SpecialTag { get; set; }

        public int Category { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int Status { get; set; }

        public string CropName { get; set; }

        public SupplierDto Supplier { get; set; }
        public CropDto Crop { get; set; }
    }
}
