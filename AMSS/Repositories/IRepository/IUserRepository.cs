using AMSS.Models;
using AMSS.Repositories.IRepository;

namespace AMSS.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> Update(ApplicationUser user);
        Task<ApplicationUser> UpdateRefreshToken(string userId, string refreshToken);
    }
}
