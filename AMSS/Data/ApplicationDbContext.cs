using AMSS.Models;
using AMSS.Models.Polygon;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SoilQuality>().HasData(
                new SoilQuality
                {
                    Id = 1,
                    InfoTime = DateTime.Now,
                    Chlorophyll = 0.1f,
                    Iron = 0.2f,
                    Nitrate = 0.3f,
                    Phyto = 0.4f,
                    Oxygen = 0.5f,
                    PH = 7.0f,
                    Phytoplankton = 0.6f,
                    Silicate = 0.7f,
                    Salinity = 0.8f,
                    SoilMoisture = 50,
                    SoilMoisture10cm = 60,
                    SoilMoisture40cm = 70,
                    SoilMoisture100cm = 80,
                    SoilTemperature = 25,
                    SoilTemperature10cm = 26,
                    SoilTemperature40cm = 27,
                    SoilTemperature100cm = 28,
                    FieldId = 3
                },
                new SoilQuality
                {
                    Id = 2,
                    InfoTime = DateTime.Now,
                    Chlorophyll = 0.2f,
                    Iron = 0.3f,
                    Nitrate = 0.4f,
                    Phyto = 0.5f,
                    Oxygen = 0.6f,
                    PH = 7.1f,
                    Phytoplankton = 0.7f,
                    Silicate = 0.8f,
                    Salinity = 0.9f,
                    SoilMoisture = 55,
                    SoilMoisture10cm = 65,
                    SoilMoisture40cm = 75,
                    SoilMoisture100cm = 85,
                    SoilTemperature = 26,
                    SoilTemperature10cm = 27,
                    SoilTemperature40cm = 28,
                    SoilTemperature100cm = 29,
                    FieldId = 5
                },
                new SoilQuality
                {
                    Id = 3,
                    InfoTime = DateTime.Now.AddDays(-1),
                    Chlorophyll = 0.15f,
                    Iron = 0.25f,
                    Nitrate = 0.35f,
                    Phyto = 0.45f,
                    Oxygen = 0.55f,
                    PH = 7.2f,
                    Phytoplankton = 0.65f,
                    Silicate = 0.75f,
                    Salinity = 0.85f,
                    SoilMoisture = 52,
                    SoilMoisture10cm = 62,
                    SoilMoisture40cm = 72,
                    SoilMoisture100cm = 82,
                    SoilTemperature = 24,
                    SoilTemperature10cm = 25,
                    SoilTemperature40cm = 26,
                    SoilTemperature100cm = 27,
                    FieldId = 6
                },
                new SoilQuality
                {
                    Id = 4,
                    InfoTime = DateTime.Now.AddDays(-2),
                    Chlorophyll = 0.12f,
                    Iron = 0.22f,
                    Nitrate = 0.32f,
                    Phyto = 0.42f,
                    Oxygen = 0.52f,
                    PH = 7.3f,
                    Phytoplankton = 0.62f,
                    Silicate = 0.72f,
                    Salinity = 0.82f,
                    SoilMoisture = 53,
                    SoilMoisture10cm = 63,
                    SoilMoisture40cm = 73,
                    SoilMoisture100cm = 83,
                    SoilTemperature = 23,
                    SoilTemperature10cm = 24,
                    SoilTemperature40cm = 25,
                    SoilTemperature100cm = 26,
                    FieldId = 7
                },
                new SoilQuality
                {
                    Id = 5,
                    InfoTime = DateTime.Now.AddDays(-3),
                    Chlorophyll = 0.11f,
                    Iron = 0.21f,
                    Nitrate = 0.31f,
                    Phyto = 0.41f,
                    Oxygen = 0.51f,
                    PH = 7.4f,
                    Phytoplankton = 0.61f,
                    Silicate = 0.71f,
                    Salinity = 0.81f,
                    SoilMoisture = 54,
                    SoilMoisture10cm = 64,
                    SoilMoisture40cm = 74,
                    SoilMoisture100cm = 84,
                    SoilTemperature = 22,
                    SoilTemperature10cm = 23,
                    SoilTemperature40cm = 24,
                    SoilTemperature100cm = 25,
                    FieldId = 8
                },
                 new SoilQuality
                 {
                     Id = 6,
                     InfoTime = DateTime.Now.AddDays(-4),
                     Chlorophyll = 0.13f,
                     Iron = 0.23f,
                     Nitrate = 0.33f,
                     Phyto = 0.43f,
                     Oxygen = 0.53f,
                     PH = 7.5f,
                     Phytoplankton = 0.63f,
                     Silicate = 0.73f,
                     Salinity = 0.83f,
                     SoilMoisture = 56,
                     SoilMoisture10cm = 66,
                     SoilMoisture40cm = 76,
                     SoilMoisture100cm = 86,
                     SoilTemperature = 21,
                     SoilTemperature10cm = 22,
                     SoilTemperature40cm = 23,
                     SoilTemperature100cm = 24,
                     FieldId = 9
                 },
                 new SoilQuality
                 {
                     Id = 7,
                     InfoTime = DateTime.Now.AddDays(-5),
                     Chlorophyll = 0.14f,
                     Iron = 0.24f,
                     Nitrate = 0.34f,
                     Phyto = 0.44f,
                     Oxygen = 0.54f,
                     PH = 7.6f,
                     Phytoplankton = 0.64f,
                     Silicate = 0.74f,
                     Salinity = 0.84f,
                     SoilMoisture = 57,
                     SoilMoisture10cm = 67,
                     SoilMoisture40cm = 77,
                     SoilMoisture100cm = 87,
                     SoilTemperature = 20,
                     SoilTemperature10cm = 21,
                     SoilTemperature40cm = 22,
                     SoilTemperature100cm = 23,
                     FieldId = 10
                 },
                new SoilQuality
                {
                    Id = 8,
                    InfoTime = DateTime.Now.AddDays(-6),
                    Chlorophyll = 0.16f,
                    Iron = 0.26f,
                    Nitrate = 0.36f,
                    Phyto = 0.46f,
                    Oxygen = 0.56f,
                    PH = 7.7f,
                    Phytoplankton = 0.66f,
                    Silicate = 0.76f,
                    Salinity = 0.86f,
                    SoilMoisture = 58,
                    SoilMoisture10cm = 68,
                    SoilMoisture40cm = 78,
                    SoilMoisture100cm = 88,
                    SoilTemperature = 19,
                    SoilTemperature10cm = 20,
                    SoilTemperature40cm = 21,
                    SoilTemperature100cm = 22,
                    FieldId = 11
                });

            modelBuilder.Entity<FieldCrop>().HasData(
                new FieldCrop
                {
                    Id = 1,
                    FieldId = 3,
                    CropId = 2,
                },
                new FieldCrop
                {
                    Id = 2,
                    FieldId = 3,
                    CropId = 1,
                },
                new FieldCrop
                {
                    Id = 3,
                    FieldId = 3,
                    CropId = 4,
                },
                new FieldCrop
                {
                    Id = 4,
                    FieldId = 5,
                    CropId = 3,
                },
                 new FieldCrop
                 {
                     Id = 5,
                     FieldId = 5,
                     CropId = 2,
                 },
                new FieldCrop
                {
                    Id = 6,
                    FieldId = 6,
                    CropId = 5,
                },
                new FieldCrop
                {
                    Id = 7,
                    FieldId = 6,
                    CropId = 7,
                },
                new FieldCrop
                {
                    Id = 8,
                    FieldId = 7,
                    CropId = 6,
                },
                new FieldCrop
                {
                    Id = 9,
                    FieldId = 7,
                    CropId = 8,
                },
                new FieldCrop
                {
                    Id = 10,
                    FieldId = 12,
                    CropId = 9,
                },
                new FieldCrop
                {
                    Id = 11,
                    FieldId = 8,
                    CropId = 10,
                },
                new FieldCrop
                {
                    Id = 12,
                    FieldId = 12,
                    CropId = 9,
                },
                new FieldCrop
                {
                    Id = 13,
                    FieldId = 8,
                    CropId = 9,
                }
                );

            modelBuilder.Entity<CropType>().HasData(
                new CropType
                {
                    Id = 1,
                    Name = "Rice",
                    Code = "RC",
                    Type = "Cereal",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 2,
                    Name = "Corn",
                    Code = "CN",
                    Type = "Cereal",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 3,
                    Name = "Soybean",
                    Code = "SB",
                    Type = "Legume",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 4,
                    Name = "Sugarcane",
                    Code = "SC",
                    Type = "Sugar Crop",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 5,
                    Name = "Potato",
                    Code = "PT",
                    Type = "Tuber",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 6,
                    Name = "Tomato",
                    Code = "TM",
                    Type = "Vegetable",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 7,
                    Name = "Apple",
                    Code = "AP",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 8,
                    Name = "Banana",
                    Code = "BN",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 9,
                    Name = "Orange",
                    Code = "OR",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 10,
                    Name = "Grapes",
                    Code = "GP",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 11,
                    Name = "Pineapple",
                    Code = "PL",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 12,
                    Name = "Strawberry",
                    Code = "SBY",
                    Type = "Fruit",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 13,
                    Name = "Coffee",
                    Code = "CF",
                    Type = "Beverage Crop",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 14,
                    Name = "Tea",
                    Code = "TE",
                    Type = "Beverage Crop",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 15,
                    Name = "Cocoa",
                    Code = "CC",
                    Type = "Beverage Crop",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 16,
                    Name = "Peanut",
                    Code = "PN",
                    Type = "Legume",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 17,
                    Name = "Carrot",
                    Code = "CR",
                    Type = "Vegetable",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new CropType
                {
                    Id = 18,
                    Name = "Broccoli",
                    Code = "BK",
                    Type = "Vegetable",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Crop>().HasData(
                 new Crop
                 {
                     Id = 1,
                     Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Rice.jpg",
                     Name = "Rice Crop 1",
                     Cycle = "Annual",
                     Edible = true,
                     Soil = "Clay",
                     Watering = "Heavy",
                     Maintenance = "Low",
                     HardinessZone = 8,
                     Indoor = false,
                     Propogation = "Seed",
                     CareLevel = "Easy",
                     GrowthRate = "Fast",
                     Description = "High-yielding rice variety suitable for wetland cultivation.",
                     CultivatedArea = 891.0,
                     PlantedDate = DateTime.Now.AddDays(-30),
                     ExpectedDate = DateTime.Now.AddDays(90),
                     Quantity = 500,
                     CropTypeId = 1,
                     CreatedAt = DateTime.Now.AddDays(-30),
                     UpdatedAt = DateTime.Now
                 },
                new Crop
                {
                    Id = 2,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Rice.jpg",
                    Name = "Rice Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Clay",
                    Watering = "Heavy",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "High-yielding rice variety suitable for wetland cultivation.",
                    CultivatedArea = 900.2,
                    PlantedDate = DateTime.Now.AddDays(-45),
                    ExpectedDate = DateTime.Now.AddDays(95),
                    Quantity = 400,
                    CropTypeId = 1,
                    CreatedAt = DateTime.Now.AddDays(-45),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 3,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Corn.jpg",
                    Name = "Corn Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Maize crop known for its versatility and use in various food products.",
                    CultivatedArea = 667.7,
                    PlantedDate = DateTime.Now.AddDays(-20),
                    ExpectedDate = DateTime.Now.AddDays(100),
                    Quantity = 700,
                    CropTypeId = 2,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 4,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Corn.jpg",
                    Name = "Corn Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Maize crop known for its versatility and use in various food products.",
                    CultivatedArea = 292.3,
                    PlantedDate = DateTime.Now.AddDays(-35),
                    ExpectedDate = DateTime.Now.AddDays(105),
                    Quantity = 600,
                    CropTypeId = 2,
                    CreatedAt = DateTime.Now.AddDays(-35),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 5,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Potato.jpg",
                    Name = "Potato Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Tuber",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Starchy tuberous crop widely consumed as a staple food.",
                    CultivatedArea = 729.4,
                    PlantedDate = DateTime.Now.AddDays(-10),
                    ExpectedDate = DateTime.Now.AddDays(130),
                    Quantity = 1000,
                    CropTypeId = 5,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 6,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Potato.jpg",
                    Name = "Potato Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Tuber",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Starchy tuberous crop widely consumed as a staple food.",
                    CultivatedArea = 834.0,
                    PlantedDate = DateTime.Now.AddDays(-25),
                    ExpectedDate = DateTime.Now.AddDays(135),
                    Quantity = 900,
                    CropTypeId = 5,
                    CreatedAt = DateTime.Now.AddDays(-25),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 7,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Tomato.jpg",
                    Name = "Tomato Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.",
                    CultivatedArea = 662.4,
                    PlantedDate = DateTime.Now.AddDays(-5),
                    ExpectedDate = DateTime.Now.AddDays(140),
                    Quantity = 1100,
                    CropTypeId = 6,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 8,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Tomato.jpg",
                    Name = "Tomato Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.",
                    CultivatedArea = 389.0,
                    PlantedDate = DateTime.Now.AddDays(-20),
                    ExpectedDate = DateTime.Now.AddDays(145),
                    Quantity = 1000,
                    CropTypeId = 6,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 9,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Apple.jpg",
                    Name = "Apple Crop 1",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "High",
                    HardinessZone = 5,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Difficult",
                    GrowthRate = "Medium",
                    Description = "Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.",
                    CultivatedArea = 732.1,
                    PlantedDate = DateTime.Now.AddDays(-5),
                    ExpectedDate = DateTime.Now.AddDays(150),
                    Quantity = 1200,
                    CropTypeId = 7,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 10,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Apple.jpg",
                    Name = "Apple Crop 2",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "High",
                    HardinessZone = 5,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Difficult",
                    GrowthRate = "Medium",
                    Description = "Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.",
                    CultivatedArea = 424.6,
                    PlantedDate = DateTime.Now.AddDays(-10),
                    ExpectedDate = DateTime.Now.AddDays(155),
                    Quantity = 1100,
                    CropTypeId = 7,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 11,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Banana.jpg",
                    Name = "Banana Crop 1",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Heavy",
                    Maintenance = "High",
                    HardinessZone = 10,
                    Indoor = false,
                    Propogation = "Sucker",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.",
                    CultivatedArea = 293.4,
                    PlantedDate = DateTime.Now.AddDays(-10),
                    ExpectedDate = DateTime.Now.AddDays(160),
                    Quantity = 1300,
                    CropTypeId = 8,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 12,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Banana.jpg",
                    Name = "Banana Crop 2",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Heavy",
                    Maintenance = "High",
                    HardinessZone = 10,
                    Indoor = false,
                    Propogation = "Sucker",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.",
                    CultivatedArea = 444.5,
                    PlantedDate = DateTime.Now.AddDays(-5),
                    ExpectedDate = DateTime.Now.AddDays(165),
                    Quantity = 1200,
                    CropTypeId = 8,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 13,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Orange.jpg",
                    Name = "Orange Crop 1",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "High",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Citrus fruit crop prized for its tangy flavor and high vitamin C content.",
                    CultivatedArea = 596.7,
                    PlantedDate = DateTime.Now.AddDays(5),
                    ExpectedDate = DateTime.Now.AddDays(170),
                    Quantity = 1400,
                    CropTypeId = 9,
                    CreatedAt = DateTime.Now.AddDays(5),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 14,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Orange.jpg",
                    Name = "Orange Crop 2",
                    Cycle = "Perennial",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "High",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Citrus fruit crop prized for its tangy flavor and high vitamin C content.",
                    CultivatedArea = 821.1,
                    PlantedDate = DateTime.Now.AddDays(-10),
                    ExpectedDate = DateTime.Now.AddDays(175),
                    Quantity = 1300,
                    CropTypeId = 9,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 15,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Grape.jpg",
                    Name = "Grapes Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Staple grain crop known for its high carbohydrate content, used in various food products.",
                    CultivatedArea = 513.3,
                    PlantedDate = DateTime.Now.AddDays(15),
                    ExpectedDate = DateTime.Now.AddDays(180),
                    Quantity = 1500,
                    CropTypeId = 10,
                    CreatedAt = DateTime.Now.AddDays(15),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 16,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Grape.jpg",
                    Name = "Grapes Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Staple grain crop known for its high carbohydrate content, used in various food products.",
                    CultivatedArea = 624.7,
                    PlantedDate = DateTime.Now.AddDays(0),
                    ExpectedDate = DateTime.Now.AddDays(185),
                    Quantity = 1400,
                    CropTypeId = 10,
                    CreatedAt = DateTime.Now.AddDays(0),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 17,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Pineapple.jpg",
                    Name = "Pineapple Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Grain crop valued for its use in food, beverages, and animal feed.",
                    CultivatedArea = 342.6,
                    PlantedDate = DateTime.Now.AddDays(-15),
                    ExpectedDate = DateTime.Now.AddDays(190),
                    Quantity = 1600,
                    CropTypeId = 11,
                    CreatedAt = DateTime.Now.AddDays(-15),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 18,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Pineapple.jpg",
                    Name = "Pineapple Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Grain crop valued for its use in food, beverages, and animal feed.",
                    CultivatedArea = 732.9,
                    PlantedDate = DateTime.Now.AddDays(-30),
                    ExpectedDate = DateTime.Now.AddDays(195),
                    Quantity = 1500,
                    CropTypeId = 11,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 19,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Strawberry.jpg",
                    Name = "Strawberry Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Medium",
                    Description = "Legume crop rich in protein, widely used in food products and animal feed.",
                    CultivatedArea = 921.8,
                    PlantedDate = DateTime.Now.AddDays(-45),
                    ExpectedDate = DateTime.Now.AddDays(200),
                    Quantity = 1700,
                    CropTypeId = 12,
                    CreatedAt = DateTime.Now.AddDays(-45),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 20,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Strawberry.jpg",
                    Name = "Strawberry Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Medium",
                    Description = "Legume crop rich in protein, widely used in food products and animal feed.",
                    CultivatedArea = 623.4,
                    PlantedDate = DateTime.Now.AddDays(-60),
                    ExpectedDate = DateTime.Now.AddDays(205),
                    Quantity = 1600,
                    CropTypeId = 12,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 21,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Coffee.jpg",
                    Name = "Coffee Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Medium",
                    Description = "Versatile crop used for food, fodder, and biofuel production.",
                    CultivatedArea = 545.1,
                    PlantedDate = DateTime.Now.AddDays(-30),
                    ExpectedDate = DateTime.Now.AddDays(210),
                    Quantity = 1800,
                    CropTypeId = 13,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 22,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Coffee.jpg",
                    Name = "Coffee Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Medium",
                    Description = "Versatile crop used for food, fodder, and biofuel production.",
                    CultivatedArea = 721.3,
                    PlantedDate = DateTime.Now.AddDays(-45),
                    ExpectedDate = DateTime.Now.AddDays(215),
                    Quantity = 1700,
                    CropTypeId = 13,
                    CreatedAt = DateTime.Now.AddDays(-45),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 23,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Cocoa.jpg",
                    Name = "Cocoa Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 7,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.",
                    CultivatedArea = 564.7,
                    PlantedDate = DateTime.Now.AddDays(-60),
                    ExpectedDate = DateTime.Now.AddDays(220),
                    Quantity = 1900,
                    CropTypeId = 15,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 24,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Cocoa.jpg",
                    Name = "Cocoa Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loamy",
                    Watering = "Moderate",
                    Maintenance = "Low",
                    HardinessZone = 7,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.",
                    CultivatedArea = 633.2,
                    PlantedDate = DateTime.Now.AddDays(-75),
                    ExpectedDate = DateTime.Now.AddDays(225),
                    Quantity = 1800,
                    CropTypeId = 15,
                    CreatedAt = DateTime.Now.AddDays(-75),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 25,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Peanut.jpg",
                    Name = "Peanut Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Clay",
                    Watering = "Heavy",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "High-yielding rice variety suitable for wetland cultivation.",
                    CultivatedArea = 712.6,
                    PlantedDate = DateTime.Now.AddDays(-25),
                    ExpectedDate = DateTime.Now.AddDays(230),
                    Quantity = 2000,
                    CropTypeId = 16,
                    CreatedAt = DateTime.Now.AddDays(-25),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 26,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Peanut.jpg",
                    Name = "Peanut Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Clay",
                    Watering = "Heavy",
                    Maintenance = "Low",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Easy",
                    GrowthRate = "Fast",
                    Description = "High-yielding rice variety suitable for wetland cultivation.",
                    CultivatedArea = 789.1,
                    PlantedDate = DateTime.Now.AddDays(-40),
                    ExpectedDate = DateTime.Now.AddDays(235),
                    Quantity = 1900,
                    CropTypeId = 16,
                    CreatedAt = DateTime.Now.AddDays(-40),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 27,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Carrot.jpg",
                    Name = "Carrot Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Maize crop known for its versatility and use in various food products.",
                    CultivatedArea = 847.3,
                    PlantedDate = DateTime.Now.AddDays(-55),
                    ExpectedDate = DateTime.Now.AddDays(240),
                    Quantity = 2100,
                    CropTypeId = 17,
                    CreatedAt = DateTime.Now.AddDays(-55),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 28,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Carrot.jpg",
                    Name = "Carrot Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 9,
                    Indoor = false,
                    Propogation = "Seed",
                    CareLevel = "Moderate",
                    GrowthRate = "Medium",
                    Description = "Maize crop known for its versatility and use in various food products.",
                    CultivatedArea = 612.4,
                    PlantedDate = DateTime.Now.AddDays(-70),
                    ExpectedDate = DateTime.Now.AddDays(245),
                    Quantity = 2000,
                    CropTypeId = 17,
                    CreatedAt = DateTime.Now.AddDays(-70),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 29,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Brocolli.jpg",
                    Name = "Broccoli Crop 1",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Tuber",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Starchy tuberous crop widely consumed as a staple food.",
                    CultivatedArea = 445.8,
                    PlantedDate = DateTime.Now.AddDays(-85),
                    ExpectedDate = DateTime.Now.AddDays(250),
                    Quantity = 2200,
                    CropTypeId = 18,
                    CreatedAt = DateTime.Now.AddDays(-85),
                    UpdatedAt = DateTime.Now
                },
                new Crop
                {
                    Id = 30,
                    Icon = "https://fucoamssimages.blob.core.windows.net/amssclient/Brocolli.jpg",
                    Name = "Broccoli Crop 2",
                    Cycle = "Annual",
                    Edible = true,
                    Soil = "Sandy Loam",
                    Watering = "Moderate",
                    Maintenance = "Medium",
                    HardinessZone = 8,
                    Indoor = false,
                    Propogation = "Tuber",
                    CareLevel = "Moderate",
                    GrowthRate = "Fast",
                    Description = "Starchy tuberous crop widely consumed as a staple food.",
                    CultivatedArea = 832.1,
                    PlantedDate = DateTime.Now.AddDays(-100),
                    ExpectedDate = DateTime.Now.AddDays(255),
                    Quantity = 2100,
                    CropTypeId = 18,
                    CreatedAt = DateTime.Now.AddDays(-100),
                    UpdatedAt = DateTime.Now
                }

            );
        }
    }
}
