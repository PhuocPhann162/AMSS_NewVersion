using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> Update(ApplicationUser user);
        Task<ApplicationUser> UpdateRefreshToken(string userId, string refreshToken);
    }
}
