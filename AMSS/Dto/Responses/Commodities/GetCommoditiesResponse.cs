using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Commodities
{
    public class GetCommoditiesResponse
    {
        [JsonPropertyName("CommdityId")]
        public Guid CommdityId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("SpecialTag")]
        public string SpecialTag { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("Image")]
        public string Image { get; set; }

        [JsonPropertyName("ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonPropertyName("Status")]
        public CommodityStatus Status { get; set; }

        [JsonPropertyName("SupplierId")]
        public Guid SupplierId { get; set; }

        [JsonPropertyName("cropId")]
        public Guid CropId { get; set; }
    }
}
