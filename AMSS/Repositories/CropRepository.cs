using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AutoMapper;

namespace AMSS.Repositories
{
    public class CropRepository : Repository<Crop>, ICropRepository
    {
        private readonly ApplicationDbContext _db;
        public CropRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Crop> Update(Crop crop)
        {
            crop.UpdatedAt = DateTime.Now;
            _db.Crops.Update(crop);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
