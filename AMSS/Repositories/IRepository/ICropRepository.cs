using AMSS.Models;

namespace AMSS.Repositories.IRepository
{
    public interface ICropRepository : IRepository<Crop>
    {
        Task<Crop> Update(Crop crop);
    }
}
