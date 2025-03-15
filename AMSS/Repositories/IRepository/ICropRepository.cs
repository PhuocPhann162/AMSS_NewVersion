
using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface ICropRepository : IRepository<Crop>
    {
        Task<Crop> Update(Crop crop);
    }
}
