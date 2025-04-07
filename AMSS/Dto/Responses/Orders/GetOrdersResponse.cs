using AMSS.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Orders
{
    public class GetOrdersResponse
    {
        [JsonPropertyName("PickupName")]
        public string PickupName { get; set; }

        [JsonPropertyName("PickupPhoneNumber")]
        public string PickupPhoneNumber { get; set; }

        [JsonPropertyName("PickupEmail")]
        public string PickupEmail { get; set; }

        [JsonPropertyName("OrderTotal")]
        public decimal OrderTotal { get; set; }

        [JsonPropertyName("DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("OrderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("Status")]
        public OrderStatus Status { get; set; }

        [JsonPropertyName("TotalItems")]
        public int TotalItems { get; set; }
    }
}
