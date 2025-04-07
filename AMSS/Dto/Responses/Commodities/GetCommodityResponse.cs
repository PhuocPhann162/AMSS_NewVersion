using AMSS.Entities;
using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Commodities
{
    public class GetCommodityResponse
    {
        [JsonPropertyName(nameof(Name))] public string Name { get; set; }

        [JsonPropertyName(nameof(Description))] public string Description { get; set; }

        [JsonPropertyName(nameof(SpecialTag))] public string SpecialTag { get; set; }

        [JsonPropertyName(nameof(Category))] public string Category { get; set; }

        [JsonPropertyName(nameof(Price))] public double Price { get; set; }

        [JsonPropertyName(nameof(Image))] public string Image { get; set; }

        [JsonPropertyName(nameof(ExpirationDate))] public DateTime? ExpirationDate { get; set; }

        [JsonPropertyName(nameof(Status))] public CommodityStatus Status { get; set; }

        [JsonPropertyName(nameof(CropName))] public string CropName { get; set; }

    }
}
