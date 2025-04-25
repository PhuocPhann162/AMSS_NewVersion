using AMSS.Data;
using AMSS.Entities;
using AMSS.Extensions;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<PaginationResult<ApplicationUser>> GetUsersByRoleAsync(
            string roleName,
            Expression<Func<ApplicationUser, bool>> expression = null,
            int page = 1,
            int pageSize = 10,
            params SortExpression<ApplicationUser>[] sortExpressions)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
                return new PaginationResult<ApplicationUser>(); 

            var query = from user in _db.Users
                        join userRole in _db.UserRoles on user.Id equals userRole.UserId
                        where userRole.RoleId == role.Id
                        select user;

            if (expression != null)
                query = query.Where(expression);

            query = GetOrderedQueryable(query, sortExpressions);

            return await query.ToPaginationAsync(page, pageSize);
        }

    }
}
