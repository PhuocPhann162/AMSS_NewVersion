using AMSS.Entities;
using AMSS.Models;
using System.Linq.Expressions;

namespace AMSS.Repositories.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> Update(ApplicationUser user);
        Task<ApplicationUser> UpdateRefreshToken(string userId, string refreshToken);

        Task<PaginationResult<ApplicationUser>> GetUsersByRoleAsync(
            string roleName,
            Expression<Func<ApplicationUser, bool>> expression = null,
            int page = 1,
            int pageSize = 10,
            params SortExpression<ApplicationUser>[] sortExpressions);
    }
}
