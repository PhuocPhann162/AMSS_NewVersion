using AMSS.Models;

namespace AMSS.Repositories.IRepository
{
    public interface IFarmRepository : IRepository<Farm>
    {
        Task<Farm> Update(Farm farm);
    }
}
