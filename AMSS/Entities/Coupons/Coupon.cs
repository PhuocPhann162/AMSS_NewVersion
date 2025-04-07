using AMSS.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Coupons
{
    public partial class Coupon : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinAmount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Expiration { get; set; }
    }
}
