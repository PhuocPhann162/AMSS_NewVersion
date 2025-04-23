using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Users
{
    public class GetCustomersResponse
    {
        [JsonPropertyName(nameof(Id))] public Guid Id { get; set; }

        [JsonPropertyName(nameof(FullName))] public string FullName { get; set; }

        [JsonPropertyName(nameof(CountryName))] public string CountryName { get; set; }

        [JsonPropertyName(nameof(CountryCode))] public string CountryCode { get; set; }

        [JsonPropertyName(nameof(ProvinceName))] public string ProvinceName { get; set; }

        [JsonPropertyName(nameof(ProvinceCode))] public string ProvinceCode { get; set; }

        [JsonPropertyName(nameof(PhoneCode))] public string PhoneCode { get; set; }

        [JsonPropertyName(nameof(PhoneNumber))] public string PhoneNumber { get; set; }

        [JsonPropertyName(nameof(Email))] public string Email { get; set; }

        [JsonPropertyName(nameof(Address))] public string Address { get; set; }

        [JsonPropertyName(nameof(CreatedAt))] public DateTime CreatedAt { get; set; }
    }
}
