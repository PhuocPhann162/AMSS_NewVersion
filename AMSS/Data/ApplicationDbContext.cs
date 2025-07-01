using AMSS.Entities;
using AMSS.Entities.CareLogs;
using AMSS.Entities.ChatRooms;
using AMSS.Entities.ChatRoomUsers;
using AMSS.Entities.Locations;
using AMSS.Entities.Messages;
using AMSS.Entities.Polygon;
using AMSS.Models.CartItems;
using AMSS.Models.Commodities;
using AMSS.Models.Coupons;
using AMSS.Models.OrderDetails;
using AMSS.Models.OrderHeaders;
using AMSS.Models.ShoppingCarts;
using AMSS.Models.Stocks;
using AMSS.Models.Suppliers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PolygonApp> PolygonApps { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<SoilQuality> SoilQualitys { get; set; }
        public DbSet<FieldCrop> FieldCrops { get; set; }
        public DbSet<CountryContinent> CountryContinents { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SeriesMetric> SeriesMetrics { get; set; }
        public DbSet<SocialMetric> SocialMetrics { get; set; }
        public DbSet<SocialYear> SocialYears { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CareLog> Carelogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Novaris");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>()
               .Property(c => c.Expiration)
               .HasColumnType("datetime")
               .HasDefaultValue(new DateTime(1900, 1, 1));
        }
    }
}
