using System.ComponentModel.DataAnnotations.Schema;
using AMSS.Models.OrderDetails;
using AMSS.Enums;
using AMSS.Entities;

namespace AMSS.Models.OrderHeaders
{
    public partial class OrderHeader : BaseModel<Guid>
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid ApplicationUserId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string PickupName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PickupPhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string PickupEmail { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal OrderTotal { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CouponCode { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string StripePaymentIntentID { get; set; }

        public OrderStatus Status { get; set; }

        public int TotalItems { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }  
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
