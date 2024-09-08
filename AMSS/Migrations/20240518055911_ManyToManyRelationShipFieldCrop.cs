using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationShipFieldCrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Fields_FieldId",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FieldId",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Crops",
                newName: "HardinessZone");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CropTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CareLevel",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cycle",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Edible",
                table: "Crops",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrowthRate",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Indoor",
                table: "Crops",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maintenance",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Propogation",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soil",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Watering",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FieldCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    CropId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldCrops_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8080), "Cereal", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8083) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8087), "Cereal", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8087) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8090), "Legume", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8092), "Sugar Crop", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8094), "Tuber", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8096), "Vegetable", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8098), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8100), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8102), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8103), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8104) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8105), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8108), "Fruit", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8110), "Beverage Crop", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8113), "Beverage Crop", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8115), "Beverage Crop", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8115) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8117), "Legume", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8119), "Vegetable", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Type", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8120), "Vegetable", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8204), "Annual", true, new DateTime(2024, 8, 16, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8202), "Fast", 8, false, "Low", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8200), "Seed", "Clay", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8206), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8211), "Annual", true, new DateTime(2024, 8, 21, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8210), "Fast", 8, false, "Low", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8210), "Seed", "Clay", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8212), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 4, 28, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8217), "Annual", true, new DateTime(2024, 8, 26, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8216), "Medium", 9, false, "Medium", new DateTime(2024, 4, 28, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8215), "Seed", "Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8218), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 4, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8222), "Annual", true, new DateTime(2024, 8, 31, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8221), "Medium", 9, false, "Medium", new DateTime(2024, 4, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8221), "Seed", "Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8223), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8227), "Annual", true, new DateTime(2024, 9, 25, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8226), "Fast", 8, false, "Medium", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8226), "Tuber", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8228), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 4, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8233), "Annual", true, new DateTime(2024, 9, 30, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8232), "Fast", 8, false, "Medium", new DateTime(2024, 4, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8231), "Tuber", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8233), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8239), "Annual", true, new DateTime(2024, 10, 5, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8238), "Fast", 9, false, "Medium", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8237), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8240), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 4, 28, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8244), "Annual", true, new DateTime(2024, 10, 10, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8243), "Fast", 9, false, "Medium", new DateTime(2024, 4, 28, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8243), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8245), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Difficult", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8249), "Perennial", true, new DateTime(2024, 10, 15, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8248), "Medium", 5, false, "High", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8248), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8250), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Difficult", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8255), "Perennial", true, new DateTime(2024, 10, 20, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8254), "Medium", 5, false, "High", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8253), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8255), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8260), "Perennial", true, new DateTime(2024, 10, 25, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8259), "Fast", 10, false, "High", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8258), "Sucker", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8260), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CareLevel", "CreatedAt", "Cycle", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8265), "Perennial", true, new DateTime(2024, 10, 30, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8264), "Fast", 10, false, "High", new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8263), "Sucker", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8266), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8270), 596.70000000000005, "Perennial", "Citrus fruit crop prized for its tangy flavor and high vitamin C content.", true, new DateTime(2024, 11, 4, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8269), "Medium", 9, false, "High", new DateTime(2024, 5, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8269), "Seed", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8271), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Indoor", "Maintenance", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8275), 821.10000000000002, "Perennial", "Citrus fruit crop prized for its tangy flavor and high vitamin C content.", true, new DateTime(2024, 11, 9, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8274), "Medium", 9, false, "High", new DateTime(2024, 5, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8274), "Seed", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8276), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 6, 2, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8281), 513.29999999999995, "Annual", "Staple grain crop known for its high carbohydrate content, used in various food products.", true, new DateTime(2024, 11, 14, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8280), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Wheat.jpg", false, "Low", "Wheat Crop 1", new DateTime(2024, 6, 2, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8279), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8281), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8286), 624.70000000000005, "Annual", "Staple grain crop known for its high carbohydrate content, used in various food products.", true, new DateTime(2024, 11, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8285), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Wheat.jpg", false, "Low", "Wheat Crop 2", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8284), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8287), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 5, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8291), 342.60000000000002, "Annual", "Grain crop valued for its use in food, beverages, and animal feed.", true, new DateTime(2024, 11, 24, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8290), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Barley.jpg", false, "Low", "Barley Crop 1", new DateTime(2024, 5, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8290), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8292), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8297), 732.89999999999998, "Annual", "Grain crop valued for its use in food, beverages, and animal feed.", true, new DateTime(2024, 11, 29, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8295), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Barley.jpg", false, "Low", "Barley Crop 2", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8295), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8298), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8302), 921.79999999999995, "Annual", "Legume crop rich in protein, widely used in food products and animal feed.", true, new DateTime(2024, 12, 4, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8301), "Medium", 8, "https://amssimages.blob.core.windows.net/agriculture/Soybean.jpg", false, "Low", "Soybean Crop 1", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8301), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8303), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 3, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8308), 623.39999999999998, "Annual", "Legume crop rich in protein, widely used in food products and animal feed.", true, new DateTime(2024, 12, 9, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8308), "Medium", 8, "https://amssimages.blob.core.windows.net/agriculture/Soybean.jpg", false, "Low", "Soybean Crop 2", new DateTime(2024, 3, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8307), "Seed", "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8309), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8314), 545.10000000000002, "Annual", "Versatile crop used for food, fodder, and biofuel production.", true, new DateTime(2024, 12, 14, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8313), "Medium", 9, "https://amssimages.blob.core.windows.net/agriculture/Sorghum.jpg", false, "Low", "Sorghum Crop 1", new DateTime(2024, 4, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8312), "Seed", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8314), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CareLevel", "CreatedAt", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8319), 721.29999999999995, "Annual", "Versatile crop used for food, fodder, and biofuel production.", true, new DateTime(2024, 12, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8318), "Medium", 9, "https://amssimages.blob.core.windows.net/agriculture/Sorghum.jpg", false, "Low", "Sorghum Crop 2", new DateTime(2024, 4, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8317), "Seed", "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8319), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 3, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8324), 14, 564.70000000000005, "Annual", "Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.", true, new DateTime(2024, 12, 24, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8323), "Fast", 7, "https://amssimages.blob.core.windows.net/agriculture/Oats.jpg", false, "Low", "Oats Crop 1", new DateTime(2024, 3, 19, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8322), "Seed", 1900, "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8325), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 3, 4, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8330), 14, 633.20000000000005, "Annual", "Cereal grain known for its high nutritional value, often used in breakfast foods and animal feed.", true, new DateTime(2024, 12, 29, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8329), "Fast", 7, "https://amssimages.blob.core.windows.net/agriculture/Oats.jpg", false, "Low", "Oats Crop 2", new DateTime(2024, 3, 4, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8329), "Seed", 1800, "Loamy", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8331), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8335), 1, 712.60000000000002, "Annual", "High-yielding rice variety suitable for wetland cultivation.", true, new DateTime(2025, 1, 3, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8334), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Rice.jpg", false, "Low", "Rice Crop 3", new DateTime(2024, 4, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8334), "Seed", 2000, "Clay", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8336), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Easy", new DateTime(2024, 4, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8341), 1, 789.10000000000002, "Annual", "High-yielding rice variety suitable for wetland cultivation.", true, new DateTime(2025, 1, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8340), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Rice.jpg", false, "Low", "Rice Crop 4", new DateTime(2024, 4, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8339), "Seed", 1900, "Clay", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8342), "Heavy" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 3, 24, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8346), 2, 847.29999999999995, "Annual", "Maize crop known for its versatility and use in various food products.", true, new DateTime(2025, 1, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8345), "Medium", 9, "https://amssimages.blob.core.windows.net/agriculture/Corn.jpg", false, "Medium", "Corn Crop 3", new DateTime(2024, 3, 24, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8344), "Seed", 2100, "Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8347), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 3, 9, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8352), 2, 612.39999999999998, "Annual", "Maize crop known for its versatility and use in various food products.", true, new DateTime(2025, 1, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8352), "Medium", 9, "https://amssimages.blob.core.windows.net/agriculture/Corn.jpg", false, "Medium", "Corn Crop 4", new DateTime(2024, 3, 9, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8350), "Seed", 2000, "Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8353), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 2, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8358), 5, 445.80000000000001, "Annual", "Starchy tuberous crop widely consumed as a staple food.", true, new DateTime(2025, 1, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8357), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Potato.jpg", false, "Medium", "Potato Crop 3", new DateTime(2024, 2, 23, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8356), "Tuber", 2200, "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8358), "Moderate" });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CareLevel", "CreatedAt", "CropTypeId", "CultivatedArea", "Cycle", "Description", "Edible", "ExpectedDate", "GrowthRate", "HardinessZone", "Icon", "Indoor", "Maintenance", "Name", "PlantedDate", "Propogation", "Quantity", "Soil", "UpdatedAt", "Watering" },
                values: new object[] { "Moderate", new DateTime(2024, 2, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8364), 5, 832.10000000000002, "Annual", "Starchy tuberous crop widely consumed as a staple food.", true, new DateTime(2025, 1, 28, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8363), "Fast", 8, "https://amssimages.blob.core.windows.net/agriculture/Potato.jpg", false, "Medium", "Potato Crop 4", new DateTime(2024, 2, 8, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8362), "Tuber", 2100, "Sandy Loam", new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(8364), "Moderate" });

            migrationBuilder.InsertData(
                table: "FieldCrops",
                columns: new[] { "Id", "CropId", "FieldId" },
                values: new object[,]
                {
                    { 1, 2, 3 },
                    { 2, 1, 3 },
                    { 3, 4, 3 },
                    { 4, 3, 5 },
                    { 5, 2, 5 },
                    { 6, 5, 6 },
                    { 7, 7, 6 },
                    { 8, 6, 7 },
                    { 9, 8, 7 },
                    { 10, 9, 12 },
                    { 11, 10, 8 },
                    { 12, 9, 12 },
                    { 13, 9, 8 }
                });

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "InfoTime",
                value: new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 2,
                column: "InfoTime",
                value: new DateTime(2024, 5, 18, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 3,
                column: "InfoTime",
                value: new DateTime(2024, 5, 17, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 4,
                column: "InfoTime",
                value: new DateTime(2024, 5, 16, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 5,
                column: "InfoTime",
                value: new DateTime(2024, 5, 15, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 6,
                column: "InfoTime",
                value: new DateTime(2024, 5, 14, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 7,
                column: "InfoTime",
                value: new DateTime(2024, 5, 13, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 8,
                column: "InfoTime",
                value: new DateTime(2024, 5, 12, 12, 59, 11, 38, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.CreateIndex(
                name: "IX_FieldCrops_CropId",
                table: "FieldCrops",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldCrops_FieldId",
                table: "FieldCrops",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldCrops");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CropTypes");

            migrationBuilder.DropColumn(
                name: "CareLevel",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Cycle",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Edible",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "GrowthRate",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Indoor",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Maintenance",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Propogation",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Soil",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Watering",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "HardinessZone",
                table: "Crops",
                newName: "FieldId");

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CropTypes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 8, 10, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2126), 7, new DateTime(2024, 4, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2124), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 8, 15, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2131), 3, new DateTime(2024, 3, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2131), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 8, 20, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2134), 5, new DateTime(2024, 4, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2134), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 8, 25, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2137), 6, new DateTime(2024, 4, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2136), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 9, 19, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2139), 3, new DateTime(2024, 5, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2139), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 9, 24, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2142), 6, new DateTime(2024, 4, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2142), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 9, 29, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2145), 5, new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2144), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 4, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2147), 6, new DateTime(2024, 4, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2147), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 9, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2150), 3, new DateTime(2024, 5, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2149), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 14, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2153), 7, new DateTime(2024, 5, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2152), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 19, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2187), 5, new DateTime(2024, 5, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2186), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 24, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2189), 3, new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2189), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 920.10000000000002, "Citrus fruit crop prized for its tangy flavor and high vitamin C content, cultivated in orchards.", new DateTime(2024, 10, 29, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2192), 6, new DateTime(2024, 5, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2191), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 349.5, "Citrus fruit crop prized for its tangy flavor and high vitamin C content, cultivated in orchards.", new DateTime(2024, 11, 3, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2195), 7, new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2194), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 542.0, "Fruit crop grown in vineyards, used for making wine, juices, and various culinary products.", new DateTime(2024, 11, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2197), 5, "https://amssimages.blob.core.windows.net/agriculture/Grape.jpg", "Grapes Crop 1", new DateTime(2024, 6, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2197), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 1300.3, "Fruit crop grown in vineyards, used for making wine, juices, and various culinary products.", new DateTime(2024, 11, 13, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2200), 6, "https://amssimages.blob.core.windows.net/agriculture/Grape.jpg", "Grapes Crop 2", new DateTime(2024, 5, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2199), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 1250.5999999999999, "Tropical fruit crop known for its sweet and tangy flavor, grown in tropical regions worldwide.", new DateTime(2024, 11, 18, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2203), 3, "https://amssimages.blob.core.windows.net/agriculture/Pineapple.jpg", "Pineapple Crop 1", new DateTime(2024, 6, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2202), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 1332.5999999999999, "Tropical fruit crop known for its sweet and tangy flavor, grown in tropical regions worldwide.", new DateTime(2024, 11, 23, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2205), 6, "https://amssimages.blob.core.windows.net/agriculture/Pineapple.jpg", "Pineapple Crop 2", new DateTime(2024, 5, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2205), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 1330.5, "Small fruit crop with a sweet flavor, often grown in gardens and commercial fields for fresh consumption.", new DateTime(2024, 11, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2208), 5, "https://amssimages.blob.core.windows.net/agriculture/Strawberry.jpg", "Strawberry Crop 1", new DateTime(2024, 6, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2207), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 1232.7, "Small fruit crop with a sweet flavor, often grown in gardens and commercial fields for fresh consumption.", new DateTime(2024, 12, 3, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2211), 7, "https://amssimages.blob.core.windows.net/agriculture/Strawberry.jpg", "Strawberry Crop 2", new DateTime(2024, 5, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2211), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 756.39999999999998, "Caffeinated beverage crop cultivated in tropical regions, harvested for its seeds (coffee beans).", new DateTime(2024, 12, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2214), 5, "https://amssimages.blob.core.windows.net/agriculture/Coffee.jpg", "Coffee Crop 1", new DateTime(2024, 6, 16, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2214), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "UpdatedAt" },
                values: new object[] { null, 842.10000000000002, "Caffeinated beverage crop cultivated in tropical regions, harvested for its seeds (coffee beans).", new DateTime(2024, 12, 13, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2217), 3, "https://amssimages.blob.core.windows.net/agriculture/Coffee.jpg", "Coffee Crop 2", new DateTime(2024, 6, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2216), null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 15, 542.29999999999995, "Bean crop used in chocolate production, cultivated in tropical regions within 20 degrees of the equator.", new DateTime(2024, 12, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2219), 6, "https://amssimages.blob.core.windows.net/agriculture/Cocoa.jpg", "Cocoa Crop 1", new DateTime(2024, 6, 26, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2219), 2000, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 15, 638.60000000000002, "Bean crop used in chocolate production, cultivated in tropical regions within 20 degrees of the equator.", new DateTime(2025, 1, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2222), 5, "https://amssimages.blob.core.windows.net/agriculture/Cocoa.jpg", "Cocoa Crop 2", new DateTime(2024, 6, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2221), 1900, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 16, 447.69999999999999, "Legume crop grown for its edible seeds, rich in protein and healthy fats, cultivated in sandy soils.", new DateTime(2025, 1, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2225), 7, "https://amssimages.blob.core.windows.net/agriculture/Peanut.jpg", "Peanut Crop 1", new DateTime(2024, 7, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2224), 2100, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 16, 1140.4000000000001, "Legume crop grown for its edible seeds, rich in protein and healthy fats, cultivated in sandy soils.", new DateTime(2025, 1, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2227), 5, "https://amssimages.blob.core.windows.net/agriculture/Peanut.jpg", "Peanut Crop 2", new DateTime(2024, 6, 16, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2227), 2000, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 17, 346.89999999999998, "Root vegetable crop known for its bright orange color and high beta-carotene content, grown in cool climates.", new DateTime(2025, 1, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2230), 6, "https://amssimages.blob.core.windows.net/agriculture/Carrot.jpg", "Carrot Crop 1", new DateTime(2024, 7, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2229), 2200, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 17, 342.60000000000002, "Root vegetable crop known for its bright orange color and high beta-carotene content, grown in cool climates.", new DateTime(2025, 1, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2232), 3, "https://amssimages.blob.core.windows.net/agriculture/Carrot.jpg", "Carrot Crop 2", new DateTime(2024, 6, 21, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2232), 2100, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 18, 748.10000000000002, "Nutrient-rich vegetable crop belonging to the brassica family, known for its green flowering heads.", new DateTime(2025, 1, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2235), 7, "https://amssimages.blob.core.windows.net/agriculture/Brocolli.jpg", "Broccoli Crop 1", new DateTime(2024, 7, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2235), 2300, null });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CropTypeId", "CultivatedArea", "Description", "ExpectedDate", "FieldId", "Icon", "Name", "PlantedDate", "Quantity", "UpdatedAt" },
                values: new object[] { null, 18, 844.0, "Nutrient-rich vegetable crop belonging to the brassica family, known for its green flowering heads.", new DateTime(2025, 2, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2238), 5, "https://amssimages.blob.core.windows.net/agriculture/Brocolli.jpg", "Broccoli Crop 2", new DateTime(2024, 6, 26, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2237), 2200, null });

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "InfoTime",
                value: new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 2,
                column: "InfoTime",
                value: new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 3,
                column: "InfoTime",
                value: new DateTime(2024, 5, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 4,
                column: "InfoTime",
                value: new DateTime(2024, 5, 10, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 5,
                column: "InfoTime",
                value: new DateTime(2024, 5, 9, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 6,
                column: "InfoTime",
                value: new DateTime(2024, 5, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 7,
                column: "InfoTime",
                value: new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "SoilQualitys",
                keyColumn: "Id",
                keyValue: 8,
                column: "InfoTime",
                value: new DateTime(2024, 5, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FieldId",
                table: "Crops",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Fields_FieldId",
                table: "Crops",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
