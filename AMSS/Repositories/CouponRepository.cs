using AMSS.Data;
using AMSS.Entities.Coupons;
using AMSS.Models.Coupons;

namespace AMSS.Repositories
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
