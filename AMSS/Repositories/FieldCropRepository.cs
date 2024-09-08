using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class FieldCropRepository : Repository<FieldCrop>, IFieldCropRepository
    {
        public FieldCropRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
