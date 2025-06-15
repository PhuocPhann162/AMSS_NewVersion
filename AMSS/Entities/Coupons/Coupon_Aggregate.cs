using AMSS.Aggregates;
using AMSS.Dto.Requests.Coupons;

namespace AMSS.Models.Coupons
{
    public partial class Coupon : IAggregateRoot
    {
        public Coupon()
        {
            
        }

        public Coupon(CreateCouponRequest request)
        {
            Id = Guid.NewGuid();
            Title = request.Title.Trim();
            Description = request.Description.Trim();
            Code = request.Code.Trim();
            DiscountAmount = request.DiscountAmount;
            MinAmount = request.MinAmount;
            Expiration = request.Expiration;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateCouponRequest request)
        {
            Title = request.Title.Trim();
            Description = request.Description.Trim();
            Code = request.Code.Trim();
            DiscountAmount = request.DiscountAmount;
            MinAmount = request.MinAmount;
            Expiration = request.Expiration;
            UpdatedAt = DateTime.Now;
        }
    }
}
