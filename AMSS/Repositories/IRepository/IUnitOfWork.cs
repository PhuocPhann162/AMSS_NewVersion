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

namespace AMSS.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICropRepository CropRepository { get; }
        ICropTypeRepository CropTypeRepository { get; }
        IFarmRepository FarmRepository { get; }
        IFieldRepository FieldRepository { get; }
        IFieldCropRepository FieldCropRepository { get; }
        ILocationRepository LocationRepository { get; }
        IPolygonAppRepository PolygonAppRepository { get; }
        IPositionRepository PositionRepository { get; }
        IUserRepository UserRepository { get; }
        ICountryContinentRepository CountryContinentRepository { get; }
        IProvinceRepository ProvinceRepository { get; }
        ISeriesMetricRepository SeriesMetricRepository { get; }
        ISocialMetricRepository SocialMetricRepository { get; }
        ISocialYearRepository SocialYearRepository { get; }
        ICommodityRepository CommodityRepository { get; }
        ICouponRepository CouponRepository { get; }
        IOrderHeaderRepository OrderHeaderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IStockRepository StockRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IMessageRepository MessageRepository { get; }
        IChatRoomRepository ChatRoomRepository { get; }
        IChatRoomUserRepository ChatRoomUserRepository { get; }
        ICareLogRepository CareLogRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
