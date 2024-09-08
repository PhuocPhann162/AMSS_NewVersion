using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Repositories
{
    public class CropTypeRepository : Repository<CropType>, ICropTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CropTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<CropType>> GetAllWithDetailsAsync()
        {
            return await _db.CropTypes
                .Include(ct => ct.Crops)
                    .ThenInclude(c => c.FieldCrops)
                        .ThenInclude(fc => fc.Field)
                            .ThenInclude(f => f.Location)
                .ToListAsync();
        }

        public async Task<CropType> Update(CropType cropType)
        {
            cropType.UpdatedAt = DateTime.Now;
            _db.CropTypes.Update(cropType);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
