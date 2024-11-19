using AMSS.Data;
using AMSS.Repositories.IRepository;
using AMSS.Repository.IRepository;

namespace AMSS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICropRepository CropRepository { get; private set; }
        public ICropTypeRepository CropTypeRepository { get; private set; }
        public IFarmRepository FarmRepository { get; private set; }
        public IFieldRepository FieldRepository { get; private set; }
        public IFieldCropRepository FieldCropRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IPolygonAppRepository PolygonAppRepository { get; private set; }
        public IPositionRepository PositionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public ICountryContinentRepository CountryContinentRepository { get; private set; }
        public IProvinceRepository ProvinceRepository { get; private set; }
        public ISeriesMetricRepository SeriesMetricRepository { get; private set; }
        public ISocialMetricRepository SocialMetricRepository { get; private set; }
        public ISocialYearRepository SocialYearRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CropRepository = new CropRepository(_db);
            CropTypeRepository = new CropTypeRepository(_db);
            FarmRepository = new FarmRepository(_db);
            FieldRepository = new FieldRepository(_db);
            FieldCropRepository = new FieldCropRepository(_db);
            LocationRepository = new LocationRepository(_db);
            PolygonAppRepository = new PolygonAppRepository(_db);
            PositionRepository = new PositionRepository(_db);
            UserRepository = new UserRepository(_db);
            CountryContinentRepository = new CountryContinentRepository(_db);
            ProvinceRepository = new ProvinceRepository(_db);
            SeriesMetricRepository = new SeriesMetricRepository(_db);
            SocialMetricRepository = new SocialMetricRepository(_db);
            SocialYearRepository = new SocialYearRepository(_db);
        }

        public void SaveAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
