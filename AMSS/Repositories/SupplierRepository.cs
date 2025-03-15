using AMSS.Data;
using AMSS.Entities.Suppliers;
using AMSS.Models.Suppliers;

namespace AMSS.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
