using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Commodities
{
    public class GetCommoditiesResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SpecialTag { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int Status { get; set; }

        public Guid SupplierId { get; set; }

        public Guid CropId { get; set; }
    }
}
