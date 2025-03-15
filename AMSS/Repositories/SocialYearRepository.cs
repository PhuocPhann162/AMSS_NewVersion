using AMSS.Data;
using AMSS.Entities;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class SocialYearRepository : Repository<SocialYear>, ISocialYearRepository
    {
        private readonly ApplicationDbContext _db;
        public SocialYearRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SocialYear> Update(SocialYear socialYear)
        {
            socialYear.UpdatedAt = DateTime.Now;
            _db.SocialYears.Update(socialYear);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
