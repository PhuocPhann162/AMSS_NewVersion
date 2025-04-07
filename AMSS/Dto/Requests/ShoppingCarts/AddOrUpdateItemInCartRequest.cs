using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.ShoppingCarts
{
    public class AddOrUpdateItemInCartRequest
    {
        [JsonPropertyName("CommodityId")]
        public Guid CommodityId { get; set; }

        [JsonPropertyName("UpdateQuantityBy")]
        public int UpdateQuantityBy { get; set; }
    }
}
