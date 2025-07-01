using AMSS.Data;
using AMSS.Entities.CareLogs;
using AMSS.Entities.CartItems;
using AMSS.Entities.ChatRooms;
using AMSS.Entities.ChatRoomUsers;
using AMSS.Entities.Commodities;
using AMSS.Entities.Coupons;
using AMSS.Entities.Messages;
using AMSS.Entities.ShoppingCarts;
using AMSS.Entities.Stocks;
using AMSS.Entities.Suppliers;
using AMSS.Models.OrderDetails;
using AMSS.Models.OrderHeaders;
using AMSS.Repositories.ChatHubRepository;
using AMSS.Repositories.IRepository;

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
        public ICommodityRepository CommodityRepository { get; private set; }
        public ICouponRepository CouponRepository { get; private set; }
        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IShoppingCartRepository ShoppingCartRepository { get; private set; }
        public ICartItemRepository CartItemRepository { get; private set; }
        public IStockRepository StockRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }
        public IChatRoomRepository ChatRoomRepository { get; private set; }
        public IChatRoomUserRepository ChatRoomUserRepository { get; private set; }
        public ICareLogRepository CareLogRepository { get; private set; }

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
            CommodityRepository = new CommodityRepository(_db);
            CouponRepository = new CouponRepository(_db);
            OrderHeaderRepository = new OrderHeaderRepository(_db);
            OrderDetailRepository = new OrderDetailRepository(_db);
            ShoppingCartRepository = new ShoppingCartRepository(_db);
            CartItemRepository = new CartItemRepository(_db);
            StockRepository = new StockRepository(_db);
            SupplierRepository = new SupplierRepository(_db);
            MessageRepository = new MessageRepository(_db);
            ChatRoomRepository = new ChatRoomRepository(_db);
            ChatRoomUserRepository = new ChatRoomUserRepository(_db);
            CareLogRepository = new CareLogRepository(_db); 
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
