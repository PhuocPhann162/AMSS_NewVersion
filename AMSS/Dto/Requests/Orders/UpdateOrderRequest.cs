using AMSS.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Orders
{
    public class UpdateOrderRequest
    {
        [StringLength(255, ErrorMessage = "Pickup name cannot exceed 255 characters")]
        public string PickupName { get; set; }

        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PickupPhoneNumber { get; set; }

        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string PickupEmail { get; set; }

        public OrderStatus Status { get; set; }
    }
}
