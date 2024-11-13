using AMSS.Data;
using AMSS.Models;
using AMSS.Repositories.IRepository;

namespace AMSS.Repositories
{
    public class CountryContinentRepository : Repository<CountryContinent>, ICountryContinentRepository
    {
        private readonly ApplicationDbContext _db;
        public CountryContinentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
