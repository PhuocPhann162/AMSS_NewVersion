using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddDescToCropTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 891.0, "High-yielding rice variety suitable for wetland cultivation.", new DateTime(2024, 7, 21, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6380), new DateTime(2024, 3, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 900.20000000000005, "High-yielding rice variety suitable for wetland cultivation.", new DateTime(2024, 7, 26, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6385), new DateTime(2024, 3, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6384) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 667.70000000000005, "Maize crop known for its versatility and use in various food products.", new DateTime(2024, 7, 31, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6388), new DateTime(2024, 4, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6387) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 292.30000000000001, "Maize crop known for its versatility and use in various food products.", new DateTime(2024, 8, 5, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 3, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 729.39999999999998, "Starchy tuberous crop widely consumed as a staple food.", new DateTime(2024, 8, 30, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6393), new DateTime(2024, 4, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 834.0, "Starchy tuberous crop widely consumed as a staple food.", new DateTime(2024, 9, 4, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6396), new DateTime(2024, 3, 28, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6396) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 662.39999999999998, "Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.", new DateTime(2024, 9, 9, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6399), new DateTime(2024, 4, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6398) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 389.0, "Versatile crop used in various culinary dishes and sauces, rich in vitamins and minerals.", new DateTime(2024, 9, 14, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 4, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6401) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 732.10000000000002, "Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.", new DateTime(2024, 9, 19, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6404), new DateTime(2024, 4, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 424.60000000000002, "Popular fruit crop known for its crisp texture and sweet flavor, cultivated in orchards worldwide.", new DateTime(2024, 9, 24, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6407), new DateTime(2024, 4, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 293.39999999999998, "Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.", new DateTime(2024, 9, 29, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6410), new DateTime(2024, 5, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 444.5, "Tropical fruit crop with high nutritional value, grown in warm climates and consumed worldwide.", new DateTime(2024, 10, 4, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6412), new DateTime(2024, 4, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 920.10000000000002, "Citrus fruit crop prized for its tangy flavor and high vitamin C content, cultivated in orchards.", new DateTime(2024, 10, 9, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6415), new DateTime(2024, 5, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 349.5, "Citrus fruit crop prized for its tangy flavor and high vitamin C content, cultivated in orchards.", new DateTime(2024, 10, 14, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6418), new DateTime(2024, 4, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6417) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 542.0, "Fruit crop grown in vineyards, used for making wine, juices, and various culinary products.", new DateTime(2024, 10, 19, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6421), new DateTime(2024, 5, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1300.3, "Fruit crop grown in vineyards, used for making wine, juices, and various culinary products.", new DateTime(2024, 10, 24, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6424), new DateTime(2024, 4, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1250.5999999999999, "Tropical fruit crop known for its sweet and tangy flavor, grown in tropical regions worldwide.", new DateTime(2024, 10, 29, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6427), new DateTime(2024, 5, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1332.5999999999999, "Tropical fruit crop known for its sweet and tangy flavor, grown in tropical regions worldwide.", new DateTime(2024, 11, 3, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6429), new DateTime(2024, 5, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6428) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1330.5, "Small fruit crop with a sweet flavor, often grown in gardens and commercial fields for fresh consumption.", new DateTime(2024, 11, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6432), new DateTime(2024, 5, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1232.7, "Small fruit crop with a sweet flavor, often grown in gardens and commercial fields for fresh consumption.", new DateTime(2024, 11, 13, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6435), new DateTime(2024, 5, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 756.39999999999998, "Caffeinated beverage crop cultivated in tropical regions, harvested for its seeds (coffee beans).", new DateTime(2024, 11, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6439), new DateTime(2024, 5, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6439) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 842.10000000000002, "Caffeinated beverage crop cultivated in tropical regions, harvested for its seeds (coffee beans).", new DateTime(2024, 11, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6442), new DateTime(2024, 5, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 542.29999999999995, "Bean crop used in chocolate production, cultivated in tropical regions within 20 degrees of the equator.", new DateTime(2024, 12, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6444), new DateTime(2024, 6, 6, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 638.60000000000002, "Bean crop used in chocolate production, cultivated in tropical regions within 20 degrees of the equator.", new DateTime(2024, 12, 13, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 5, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 447.69999999999999, "Legume crop grown for its edible seeds, rich in protein and healthy fats, cultivated in sandy soils.", new DateTime(2024, 12, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6450), new DateTime(2024, 6, 11, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6449) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 1140.4000000000001, "Legume crop grown for its edible seeds, rich in protein and healthy fats, cultivated in sandy soils.", new DateTime(2024, 12, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6453), new DateTime(2024, 5, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 346.89999999999998, "Root vegetable crop known for its bright orange color and high beta-carotene content, grown in cool climates.", new DateTime(2024, 12, 28, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6455), new DateTime(2024, 6, 16, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 342.60000000000002, "Root vegetable crop known for its bright orange color and high beta-carotene content, grown in cool climates.", new DateTime(2025, 1, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6482), new DateTime(2024, 6, 1, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 748.10000000000002, "Nutrient-rich vegetable crop belonging to the brassica family, known for its green flowering heads.", new DateTime(2025, 1, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6485), new DateTime(2024, 6, 21, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CultivatedArea", "Description", "ExpectedDate", "PlantedDate" },
                values: new object[] { 844.0, "Nutrient-rich vegetable crop belonging to the brassica family, known for its green flowering heads.", new DateTime(2025, 1, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6487), new DateTime(2024, 6, 6, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6487) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Crops");

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 10.5, new DateTime(2024, 7, 20, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7461), new DateTime(2024, 3, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 8.1999999999999993, new DateTime(2024, 7, 25, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7464), new DateTime(2024, 3, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 15.699999999999999, new DateTime(2024, 7, 30, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7467), new DateTime(2024, 4, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7467) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 12.300000000000001, new DateTime(2024, 8, 4, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 3, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 22.5, new DateTime(2024, 8, 29, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7472), new DateTime(2024, 4, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 18.699999999999999, new DateTime(2024, 9, 3, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7475), new DateTime(2024, 3, 27, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 24.100000000000001, new DateTime(2024, 9, 8, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 4, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 20.5, new DateTime(2024, 9, 13, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 4, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7481) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 26.300000000000001, new DateTime(2024, 9, 18, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7484), new DateTime(2024, 4, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 22.800000000000001, new DateTime(2024, 9, 23, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7486), new DateTime(2024, 4, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 28.600000000000001, new DateTime(2024, 9, 28, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7489), new DateTime(2024, 5, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 24.899999999999999, new DateTime(2024, 10, 3, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7491), new DateTime(2024, 4, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7491) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 30.899999999999999, new DateTime(2024, 10, 8, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7494), new DateTime(2024, 5, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 26.699999999999999, new DateTime(2024, 10, 13, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 4, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 32.399999999999999, new DateTime(2024, 10, 18, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7499), new DateTime(2024, 5, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7498) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 28.100000000000001, new DateTime(2024, 10, 23, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7502), new DateTime(2024, 4, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7501) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 34.700000000000003, new DateTime(2024, 10, 28, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7504), new DateTime(2024, 5, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 30.5, new DateTime(2024, 11, 2, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7508), new DateTime(2024, 5, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 36.200000000000003, new DateTime(2024, 11, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7510), new DateTime(2024, 5, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 32.0, new DateTime(2024, 11, 12, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7513), new DateTime(2024, 5, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 38.0, new DateTime(2024, 11, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7515), new DateTime(2024, 5, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 34.0, new DateTime(2024, 11, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7518), new DateTime(2024, 5, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 42.299999999999997, new DateTime(2024, 12, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7520), new DateTime(2024, 6, 5, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 38.600000000000001, new DateTime(2024, 12, 12, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7523), new DateTime(2024, 5, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 44.700000000000003, new DateTime(2024, 12, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7525), new DateTime(2024, 6, 10, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 40.399999999999999, new DateTime(2024, 12, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7528), new DateTime(2024, 5, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 46.899999999999999, new DateTime(2024, 12, 27, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7530), new DateTime(2024, 6, 15, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 42.600000000000001, new DateTime(2025, 1, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7532), new DateTime(2024, 5, 31, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 48.100000000000001, new DateTime(2025, 1, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7535), new DateTime(2024, 6, 20, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CultivatedArea", "ExpectedDate", "PlantedDate" },
                values: new object[] { 44.0, new DateTime(2025, 1, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7537), new DateTime(2024, 6, 5, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7537) });
        }
    }
}
