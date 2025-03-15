using AMSS.Data;
using AMSS.Entities;
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
