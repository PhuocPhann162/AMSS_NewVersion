using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Orders
{
    public class CreateOrderRequest
    {
        [Required]
        [StringLength(255, ErrorMessage = "Pickup name cannot exceed 255 characters")]
        public string PickupName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PickupPhoneNumber { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string PickupEmail { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Order total must be a positive value")]
        public decimal OrderTotal { get; set; }

        [StringLength(50, ErrorMessage = "Coupon code cannot exceed 50 characters")]
        public string CouponCode { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be a positive value")]
        public decimal DiscountAmount { get; set; }

        public string StripePaymentIntentID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total items must be at least 1")]
        public int TotalItems { get; set; }

        [Required]
        public List<OrderDetailRequest> OrderDetails { get; set; }
    }

    public class OrderDetailRequest
    {
        [Required]
        public Guid CommodityId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters")]
        public string ItemName { get; set; }
    }
}
