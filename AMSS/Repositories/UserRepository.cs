using AMSS.Data;
using AMSS.Models;
using AMSS.Repository.IRepository;

namespace AMSS.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            user.UpdatedAt = DateTime.Now;
            _db.ApplicationUsers.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<ApplicationUser> UpdateRefreshToken(string userId, string refreshToken)
        {
            var user = await this.GetAsync(u => u.Id == userId);
            user.RefreshToken = refreshToken;
            await this.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
