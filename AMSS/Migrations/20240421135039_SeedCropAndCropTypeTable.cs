using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class SeedCropAndCropTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CropTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "RC", "Rice" },
                    { 2, "CN", "Corn" },
                    { 3, "SB", "Soybean" },
                    { 4, "SC", "Sugarcane" },
                    { 5, "PT", "Potato" },
                    { 6, "TM", "Tomato" },
                    { 7, "AP", "Apple" },
                    { 8, "BN", "Banana" },
                    { 9, "OR", "Orange" },
                    { 10, "GP", "Grapes" },
                    { 11, "PL", "Pineapple" },
                    { 12, "SBY", "Strawberry" },
                    { 13, "CF", "Coffee" },
                    { 14, "TE", "Tea" },
                    { 15, "CC", "Cocoa" },
                    { 16, "PN", "Peanut" },
                    { 17, "CR", "Carrot" },
                    { 18, "BK", "Broccoli" }
                });

            migrationBuilder.InsertData(
                table: "Crops",
                columns: new[] { "Id", "CreatedAt", "CropTypeId", "CultivatedArea", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 1, 10.5, new DateTime(2024, 7, 20, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2133), 7, "https://amssimages.blob.core.windows.net/agriculture/Rice.jpg", "Rice Crop 1", new DateTime(2024, 3, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2109), 500, null },
                    { 2, null, 1, 8.1999999999999993, new DateTime(2024, 7, 25, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2137), 3, "https://amssimages.blob.core.windows.net/agriculture/Rice.jpg", "Rice Crop 2", new DateTime(2024, 3, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2136), 400, null },
                    { 3, null, 2, 15.699999999999999, new DateTime(2024, 7, 30, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2140), 5, "https://amssimages.blob.core.windows.net/agriculture/Corn.jpg", "Corn Crop 1", new DateTime(2024, 4, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2140), 700, null },
                    { 4, null, 2, 12.300000000000001, new DateTime(2024, 8, 4, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2177), 6, "https://amssimages.blob.core.windows.net/agriculture/Corn.jpg", "Corn Crop 2", new DateTime(2024, 3, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2176), 600, null },
                    { 5, null, 5, 22.5, new DateTime(2024, 8, 29, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2180), 3, "https://amssimages.blob.core.windows.net/agriculture/Potato.jpg", "Potato Crop 1", new DateTime(2024, 4, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2179), 1000, null },
                    { 6, null, 5, 18.699999999999999, new DateTime(2024, 9, 3, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2183), 6, "https://amssimages.blob.core.windows.net/agriculture/Potato.jpg", "Potato Crop 2", new DateTime(2024, 3, 27, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2182), 900, null },
                    { 7, null, 6, 24.100000000000001, new DateTime(2024, 9, 8, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2186), 5, "https://amssimages.blob.core.windows.net/agriculture/Tomato.jpg", "Tomato Crop 1", new DateTime(2024, 4, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2185), 1100, null },
                    { 8, null, 6, 20.5, new DateTime(2024, 9, 13, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2189), 6, "https://amssimages.blob.core.windows.net/agriculture/Tomato.jpg", "Tomato Crop 2", new DateTime(2024, 4, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2188), 1000, null },
                    { 9, null, 7, 26.300000000000001, new DateTime(2024, 9, 18, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2192), 3, "https://amssimages.blob.core.windows.net/agriculture/Apple.jpg", "Apple Crop 1", new DateTime(2024, 4, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2191), 1200, null },
                    { 10, null, 7, 22.800000000000001, new DateTime(2024, 9, 23, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2195), 7, "https://amssimages.blob.core.windows.net/agriculture/Apple.jpg", "Apple Crop 2", new DateTime(2024, 4, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2194), 1100, null },
                    { 11, null, 8, 28.600000000000001, new DateTime(2024, 9, 28, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2197), 5, "https://amssimages.blob.core.windows.net/agriculture/Banana.jpg", "Banana Crop 1", new DateTime(2024, 5, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2197), 1300, null },
                    { 12, null, 8, 24.899999999999999, new DateTime(2024, 10, 3, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2200), 3, "https://amssimages.blob.core.windows.net/agriculture/Banana.jpg", "Banana Crop 2", new DateTime(2024, 4, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2199), 1200, null },
                    { 13, null, 9, 30.899999999999999, new DateTime(2024, 10, 8, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2203), 6, "https://amssimages.blob.core.windows.net/agriculture/Orange.jpg", "Orange Crop 1", new DateTime(2024, 5, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2202), 1400, null },
                    { 14, null, 9, 26.699999999999999, new DateTime(2024, 10, 13, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2206), 7, "https://amssimages.blob.core.windows.net/agriculture/Orange.jpg", "Orange Crop 2", new DateTime(2024, 4, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2205), 1300, null },
                    { 15, null, 10, 32.399999999999999, new DateTime(2024, 10, 18, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2209), 5, "https://amssimages.blob.core.windows.net/agriculture/Grape.jpg", "Grapes Crop 1", new DateTime(2024, 5, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2208), 1500, null },
                    { 16, null, 10, 28.100000000000001, new DateTime(2024, 10, 23, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2212), 6, "https://amssimages.blob.core.windows.net/agriculture/Grape.jpg", "Grapes Crop 2", new DateTime(2024, 4, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2212), 1400, null },
                    { 17, null, 11, 34.700000000000003, new DateTime(2024, 10, 28, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2215), 3, "https://amssimages.blob.core.windows.net/agriculture/Pineapple.jpg", "Pineapple Crop 1", new DateTime(2024, 5, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2215), 1600, null },
                    { 18, null, 11, 30.5, new DateTime(2024, 11, 2, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2218), 6, "https://amssimages.blob.core.windows.net/agriculture/Pineapple.jpg", "Pineapple Crop 2", new DateTime(2024, 5, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2218), 1500, null },
                    { 19, null, 12, 36.200000000000003, new DateTime(2024, 11, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2221), 5, "https://amssimages.blob.core.windows.net/agriculture/Strawberry.jpg", "Strawberry Crop 1", new DateTime(2024, 5, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2220), 1700, null },
                    { 20, null, 12, 32.0, new DateTime(2024, 11, 12, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2224), 7, "https://amssimages.blob.core.windows.net/agriculture/Strawberry.jpg", "Strawberry Crop 2", new DateTime(2024, 5, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2223), 1600, null },
                    { 21, null, 13, 38.0, new DateTime(2024, 11, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2226), 5, "https://amssimages.blob.core.windows.net/agriculture/Coffee.jpg", "Coffee Crop 1", new DateTime(2024, 5, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2226), 1800, null },
                    { 22, null, 13, 34.0, new DateTime(2024, 11, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2229), 3, "https://amssimages.blob.core.windows.net/agriculture/Coffee.jpg", "Coffee Crop 2", new DateTime(2024, 5, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2228), 1700, null },
                    { 23, null, 15, 42.299999999999997, new DateTime(2024, 12, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2232), 6, "https://amssimages.blob.core.windows.net/agriculture/Cocoa.jpg", "Cocoa Crop 1", new DateTime(2024, 6, 5, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2231), 2000, null },
                    { 24, null, 15, 38.600000000000001, new DateTime(2024, 12, 12, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2235), 5, "https://amssimages.blob.core.windows.net/agriculture/Cocoa.jpg", "Cocoa Crop 2", new DateTime(2024, 5, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2234), 1900, null },
                    { 25, null, 16, 44.700000000000003, new DateTime(2024, 12, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2238), 7, "https://amssimages.blob.core.windows.net/agriculture/Peanut.jpg", "Peanut Crop 1", new DateTime(2024, 6, 10, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2237), 2100, null },
                    { 26, null, 16, 40.399999999999999, new DateTime(2024, 12, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2240), 5, "https://amssimages.blob.core.windows.net/agriculture/Peanut.jpg", "Peanut Crop 2", new DateTime(2024, 5, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2240), 2000, null },
                    { 27, null, 17, 46.899999999999999, new DateTime(2024, 12, 27, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2243), 6, "https://amssimages.blob.core.windows.net/agriculture/Carrot.jpg", "Carrot Crop 1", new DateTime(2024, 6, 15, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2242), 2200, null },
                    { 28, null, 17, 42.600000000000001, new DateTime(2025, 1, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2246), 3, "https://amssimages.blob.core.windows.net/agriculture/Carrot.jpg", "Carrot Crop 2", new DateTime(2024, 5, 31, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2245), 2100, null },
                    { 29, null, 18, 48.100000000000001, new DateTime(2025, 1, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2248), 7, "https://amssimages.blob.core.windows.net/agriculture/Brocolli.jpg", "Broccoli Crop 1", new DateTime(2024, 6, 20, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2248), 2300, null },
                    { 30, null, 18, 44.0, new DateTime(2025, 1, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2251), 5, "https://amssimages.blob.core.windows.net/agriculture/Brocolli.jpg", "Broccoli Crop 2", new DateTime(2024, 6, 5, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2251), 2200, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
