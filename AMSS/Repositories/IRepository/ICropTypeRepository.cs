using AMSS.Models;

namespace AMSS.Repositories.IRepository
{
    public interface ICropTypeRepository : IRepository<CropType>
    {
        Task<List<CropType>> GetAllWithDetailsAsync();
        Task<CropType> Update(CropType cropType);
    }
}
