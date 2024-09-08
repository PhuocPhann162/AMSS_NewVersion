using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Repositories
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        private readonly ApplicationDbContext _db;
        public FieldRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Field>> GetAllFieldWithDetailAsync()
        {
            return await _db.Fields
            .Include(f => f.Location)
            .Include(f => f.PolygonApp)
            .ThenInclude(p => p.Positions)
            .Include(f => f.Farm)
            .Include(f => f.FieldCrops).ToListAsync();
        }

        public async Task<Field> Update(Field field)
        {
            field.UpdatedAt = DateTime.Now;
            _db.Fields.Update(field);
            await _db.SaveChangesAsync();
            return null;
        }
    }
}
