using AMSS.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Orders
{
    public class GetOrdersResponse
    {
        public Guid Id { get; set; }
        public string PickupName { get; set; }

        public string PickupPhoneNumber { get; set; }

        public string PickupEmail { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public int Status { get; set; }

        public int TotalItems { get; set; }
    }
}
