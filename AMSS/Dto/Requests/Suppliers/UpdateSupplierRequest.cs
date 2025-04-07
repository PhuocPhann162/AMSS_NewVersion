using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Suppliers
{
    public class UpdateSupplierRequest
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Name")]
        public string ContactName { get; set; }

        [JsonPropertyName("Name")]
        public string PhoneCode { get; set; }

        [JsonPropertyName("Name")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Name")]
        public string Email { get; set; }

        [JsonPropertyName("Name")]
        public string Address { get; set; }
    }
}
