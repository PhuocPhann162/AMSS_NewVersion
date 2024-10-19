using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class SeedCropTypeAndCropTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    IF NOT EXISTS (SELECT * FROM [AMSS_N].[dbo].[CropTypes] WHERE Code = 'RC') 
                    BEGIN 
                        DECLARE @RiceId UNIQUEIDENTIFIER = NEWID(),
                                        @CornId UNIQUEIDENTIFIER = NEWID(),
                                        @SoybeanId UNIQUEIDENTIFIER = NEWID(),
                                        @SugarcaneId UNIQUEIDENTIFIER = NEWID(),
                                        @PotatoId UNIQUEIDENTIFIER = NEWID(),
                                        @TomatoId UNIQUEIDENTIFIER = NEWID(),
                                        @AppleId UNIQUEIDENTIFIER = NEWID(),
                                        @BananaId UNIQUEIDENTIFIER = NEWID(),
                                        @OrangeId UNIQUEIDENTIFIER = NEWID(),
                                        @GrapesId UNIQUEIDENTIFIER = NEWID(),
                                        @PineappleId UNIQUEIDENTIFIER = NEWID(),
                                        @StrawberryId UNIQUEIDENTIFIER = NEWID(),
                                        @CoffeeId UNIQUEIDENTIFIER = NEWID(),
                                        @TeaId UNIQUEIDENTIFIER = NEWID(),
                                        @CocoaId UNIQUEIDENTIFIER = NEWID(),
                                        @PeanutId UNIQUEIDENTIFIER = NEWID(),
                                        @CarrotId UNIQUEIDENTIFIER = NEWID(),
                                        @BroccoliId UNIQUEIDENTIFIER = NEWID();

                        INSERT INTO CropTypes (Id, Name, Code, Type, CreatedAt, UpdatedAt) 
                        VALUES
                                (@RiceId, 'Rice', 'RC', 'Cereal', GETDATE(), GETDATE()),
                                (@CornId, 'Corn', 'CN', 'Cereal', GETDATE(), GETDATE()),
                                (@SoybeanId, 'Soybean', 'SB', 'Legume', GETDATE(), GETDATE()),
                                (@SugarcaneId, 'Sugarcane', 'SC', 'Sugar Crop', GETDATE(), GETDATE()),
                                (@PotatoId, 'Potato', 'PT', 'Tuber', GETDATE(), GETDATE()),
                                (@TomatoId, 'Tomato', 'TM', 'Vegetable', GETDATE(), GETDATE()),
                                (@AppleId, 'Apple', 'AP', 'Fruit', GETDATE(), GETDATE()),
                                (@BananaId, 'Banana', 'BN', 'Fruit', GETDATE(), GETDATE()),
                                (@OrangeId, 'Orange', 'OR', 'Fruit', GETDATE(), GETDATE()),
                                (@GrapesId, 'Grapes', 'GP', 'Fruit', GETDATE(), GETDATE()),
                                (@PineappleId, 'Pineapple', 'PL', 'Fruit', GETDATE(), GETDATE()),
                                (@StrawberryId, 'Strawberry', 'SBY', 'Fruit', GETDATE(), GETDATE()),
                                (@CoffeeId, 'Coffee', 'CF', 'Beverage Crop', GETDATE(), GETDATE()),
                                (@TeaId, 'Tea', 'TE', 'Beverage Crop', GETDATE(), GETDATE()),
                                (@CocoaId, 'Cocoa', 'CC', 'Beverage Crop', GETDATE(), GETDATE()),
                                (@PeanutId, 'Peanut', 'PN', 'Legume', GETDATE(), GETDATE()),
                                (@CarrotId, 'Carrot', 'CR', 'Vegetable', GETDATE(), GETDATE()),
                                (@BroccoliId, 'Broccoli', 'BK', 'Vegetable', GETDATE(), GETDATE());

                        INSERT INTO Crops (Id, Icon, Name, Cycle, Edible, Soil, Watering, Maintenance, HardinessZone, Indoor, Propogation, CareLevel, GrowthRate, Description, CultivatedArea, PlantedDate, ExpectedDate, Quantity, CropTypeId, CreatedAt, UpdatedAt)
                        VALUES
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Rice.jpg', 'Rice Crop 1', 'Annual', 1, 'Clay', 'Heavy', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'High-yielding rice variety suitable for wetland cultivation.', 891.0, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, 90, GETDATE()), 500, @RiceId, DATEADD(DAY, -30, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Rice.jpg', 'Rice Crop 2', 'Annual', 1, 'Clay', 'Heavy', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'High-yielding rice variety suitable for wetland cultivation.', 900.2, DATEADD(DAY, -45, GETDATE()), DATEADD(DAY, 95, GETDATE()), 400, @RiceId, DATEADD(DAY, -45, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Corn.jpg', 'Corn Crop 1', 'Annual', 1, 'Loam', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Medium', 'Maize crop known for its versatility and use in various food products.', 667.7, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, 100, GETDATE()), 700, @CornId, DATEADD(DAY, -20, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Corn.jpg', 'Corn Crop 2', 'Annual', 1, 'Loam', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Medium', 'Maize crop known for its versatility and use in various food products.', 292.3, DATEADD(DAY, -35, GETDATE()), DATEADD(DAY, 105, GETDATE()), 600, @CornId, DATEADD(DAY, -35, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Potato.jpg', 'Potato Crop 1', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Medium', 8, 0, 'Tuber', 'Moderate', 'Fast', 'Starchy tuberous crop widely consumed as a staple food.', 729.4, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 130, GETDATE()), 1000, @PotatoId, DATEADD(DAY, -10, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Potato.jpg', 'Potato Crop 2', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Medium', 8, 0, 'Tuber', 'Moderate', 'Fast', 'Starchy tuberous crop widely consumed as a staple food.', 834.0, DATEADD(DAY, -25, GETDATE()), DATEADD(DAY, 135, GETDATE()), 900, @PotatoId, DATEADD(DAY, -25, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Tomato.jpg', 'Tomato Crop 1', 'Annual', 1, 'Loamy', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Fast', 'Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.', 662.4, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 140, GETDATE()), 1100, @TomatoId, DATEADD(DAY, -5, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Tomato.jpg', 'Tomato Crop 2', 'Annual', 1, 'Loamy', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Fast', 'Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.', 389.0, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, 145, GETDATE()), 1000, @TomatoId, DATEADD(DAY, -20, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Apple.jpg', 'Apple Crop 1', 'Perennial', 1, 'Loamy', 'Moderate', 'High', 5, 0, 'Seed', 'Difficult', 'Medium', 'Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.', 732.1, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 150, GETDATE()), 1200, @AppleId, DATEADD(DAY, -5, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Apple.jpg', 'Apple Crop 2', 'Perennial', 1, 'Loamy', 'Moderate', 'High', 5, 0, 'Seed', 'Difficult', 'Medium', 'Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.', 424.6, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 155, GETDATE()), 1100, @AppleId, DATEADD(DAY, -10, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Banana.jpg', 'Banana Crop 1', 'Perennial', 1, 'Loamy', 'Heavy', 'High', 10, 0, 'Sucker', 'Moderate', 'Fast', 'Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.', 293.4, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 160, GETDATE()), 1300, @BananaId, DATEADD(DAY, -10, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Banana.jpg', 'Banana Crop 2', 'Perennial', 1, 'Loamy', 'Heavy', 'High', 10, 0, 'Sucker', 'Moderate', 'Fast', 'Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.', 444.5, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 165, GETDATE()), 1200, @BananaId, DATEADD(DAY, -5, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Orange.jpg', 'Orange Crop 1', 'Perennial', 1, 'Sandy Loam', 'Moderate', 'High', 9, 0, 'Seed', 'Moderate', 'Medium', 'Citrus fruit crop prized for its tangy flavor and high vitamin C content.', 596.7, DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 170, GETDATE()), 1400, @OrangeId, DATEADD(DAY, 5, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Orange.jpg', 'Orange Crop 2', 'Perennial', 1, 'Sandy Loam', 'Moderate', 'High', 9, 0, 'Seed', 'Moderate', 'Medium', 'Citrus fruit crop prized for its tangy flavor and high vitamin C content.', 821.1, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 175, GETDATE()), 1300, @OrangeId, DATEADD(DAY, -10, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Grape.jpg', 'Grapes Crop 1', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'Staple grain crop known for its high carbohydrate content, used in various food products.', 513.3, DATEADD(DAY, 15, GETDATE()), DATEADD(DAY, 180, GETDATE()), 1500, @GrapesId, DATEADD(DAY, 15, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Grape.jpg', 'Grapes Crop 2', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'Staple grain crop known for its high carbohydrate content, used in various food products.', 490.5, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, 185, GETDATE()), 1400, @GrapesId, DATEADD(DAY, -20, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Pineapple.jpg', 'Pineapple Crop 1', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'Grain crop valued for its use in food, beverages, and animal feed.', 342.6, DATEADD(DAY, -15, GETDATE()), DATEADD(DAY, 190, GETDATE()), 1600, @PineappleId, DATEADD(DAY, -15, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Pineapple.jpg', 'Pineapple Crop 2', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'Grain crop valued for its use in food, beverages, and animal feed.', 732.9, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, 195, GETDATE()), 1500, @PineappleId, DATEADD(DAY, -30, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Strawberry.jpg', 'Strawberry Crop 1', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Medium', 'Legume crop rich in protein, widely used in food products and animal feed.', 921.8, DATEADD(DAY, -45, GETDATE()), DATEADD(DAY, 200, GETDATE()), 1700, @StrawberryId, DATEADD(DAY, -45, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Strawberry.jpg', 'Strawberry Crop 2', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 8, 0, 'Seed', 'Easy', 'Medium', 'Legume crop rich in protein, widely used in food products and animal feed.', 623.4, DATEADD(DAY, -60, GETDATE()), DATEADD(DAY, 205, GETDATE()), 1600, @StrawberryId, DATEADD(DAY, -60, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Coffee.jpg', 'Coffee Crop 1', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Low', 9, 0, 'Seed', 'Easy', 'Medium', 'Versatile crop used for food, fodder, and biofuel production.', 545.1, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, 210, GETDATE()), 1800, @CoffeeId, DATEADD(DAY, -30, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Coffee.jpg', 'Coffee Crop 2', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Low', 9, 0, 'Seed', 'Easy', 'Medium', 'Versatile crop used for food, fodder, and biofuel production.', 721.3, DATEADD(DAY, -45, GETDATE()), DATEADD(DAY, 215, GETDATE()), 1700, @CoffeeId, DATEADD(DAY, -45, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Cocoa.jpg', 'Cocoa Crop 1', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 7, 0, 'Seed', 'Easy', 'Fast', 'Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.', 564.7, DATEADD(DAY, -60, GETDATE()), DATEADD(DAY, 220, GETDATE()), 1900, @CocoaId, DATEADD(DAY, -60, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Cocoa.jpg', 'Cocoa Crop 2', 'Annual', 1, 'Loamy', 'Moderate', 'Low', 7, 0, 'Seed', 'Easy', 'Fast', 'Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.', 633.2, DATEADD(DAY, -75, GETDATE()), DATEADD(DAY, 225, GETDATE()), 1800, @CocoaId, DATEADD(DAY, -75, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Peanut.jpg', 'Peanut Crop 1', 'Annual', 1, 'Clay', 'Heavy', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'High-yielding rice variety suitable for wetland cultivation.', 712.6, DATEADD(DAY, -25, GETDATE()), DATEADD(DAY, 230, GETDATE()), 2000, @PeanutId, DATEADD(DAY, -25, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Peanut.jpg', 'Peanut Crop 2', 'Annual', 1, 'Clay', 'Heavy', 'Low', 8, 0, 'Seed', 'Easy', 'Fast', 'High-yielding rice variety suitable for wetland cultivation.', 834.8, DATEADD(DAY, -50, GETDATE()), DATEADD(DAY, 235, GETDATE()), 1900, @PeanutId, DATEADD(DAY, -50, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Carrot.jpg', 'Carrot Crop 1', 'Annual', 1, 'Loam', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Medium', 'Maize crop known for its versatility and use in various food products.', 847.3, DATEADD(DAY, -55, GETDATE()), DATEADD(DAY, 240, GETDATE()), 2100, @CarrotId, DATEADD(DAY, -55, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Carrot.jpg', 'Carrot Crop 2', 'Annual', 1, 'Loam', 'Moderate', 'Medium', 9, 0, 'Seed', 'Moderate', 'Medium', 'Maize crop known for its versatility and use in various food products.', 612.4, DATEADD(DAY, -70, GETDATE()), DATEADD(DAY, 245, GETDATE()), 2000, @CarrotId, DATEADD(DAY, -70, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Brocolli.jpg', 'Broccoli Crop 1', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Medium', 8, 0, 'Tuber', 'Moderate', 'Fast', 'Starchy tuberous crop widely consumed as a staple food.', 445.8, DATEADD(DAY, -85, GETDATE()), DATEADD(DAY, 250, GETDATE()), 2200, @BroccoliId, DATEADD(DAY, -85, GETDATE()), GETDATE()),
                        (NEWID(), 'https://fucoamssimages.blob.core.windows.net/amssclient/Brocolli.jpg', 'Broccoli Crop 2', 'Annual', 1, 'Sandy Loam', 'Moderate', 'Medium', 8, 0, 'Tuber', 'Moderate', 'Fast', 'Starchy tuberous crop widely consumed as a staple food.', 832.1, DATEADD(DAY, -100, GETDATE()), DATEADD(DAY, 255, GETDATE()), 2100, @BroccoliId, DATEADD(DAY, -100, GETDATE()), GETDATE());
                    END"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
