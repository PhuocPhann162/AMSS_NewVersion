using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.ShoppingCarts
{
    public class AddOrUpdateItemInCartRequest
    {
        public Guid CommodityId { get; set; }

        public int UpdateQuantityBy { get; set; }
    }
}
