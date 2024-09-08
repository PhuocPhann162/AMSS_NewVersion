using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddSoilQualityTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoilQualitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chlorophyll = table.Column<float>(type: "real", nullable: false),
                    Iron = table.Column<float>(type: "real", nullable: false),
                    Nitrate = table.Column<float>(type: "real", nullable: false),
                    Phyto = table.Column<float>(type: "real", nullable: false),
                    Oxygen = table.Column<float>(type: "real", nullable: false),
                    PH = table.Column<float>(type: "real", nullable: false),
                    Phytoplankton = table.Column<float>(type: "real", nullable: false),
                    Silicate = table.Column<float>(type: "real", nullable: false),
                    Salinity = table.Column<float>(type: "real", nullable: false),
                    SoilMoisture = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture10cm = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture40cm = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture100cm = table.Column<int>(type: "int", nullable: false),
                    SoilTemperature = table.Column<int>(type: "int", nullable: false),
                    SoilTemperature10cm = table.Column<int>(type: "int", nullable: false),
                    SoilTemperature40cm = table.Column<int>(type: "int", nullable: false),
                    SoilTemperature100cm = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilQualitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoilQualitys_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 10, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2126), new DateTime(2024, 4, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 15, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2131), new DateTime(2024, 3, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2134), new DateTime(2024, 4, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 25, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2137), new DateTime(2024, 4, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 19, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2139), new DateTime(2024, 5, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2142), new DateTime(2024, 4, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2142) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 29, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2145), new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 4, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2147), new DateTime(2024, 4, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 9, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2150), new DateTime(2024, 5, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 14, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 5, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2152) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 19, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2187), new DateTime(2024, 5, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 24, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2189), new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2192), new DateTime(2024, 5, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2195), new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2194) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2197), new DateTime(2024, 6, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2200), new DateTime(2024, 5, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2203), new DateTime(2024, 6, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 23, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2205), new DateTime(2024, 5, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2208), new DateTime(2024, 6, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 3, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2211), new DateTime(2024, 5, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2211) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2214), new DateTime(2024, 6, 16, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 13, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2217), new DateTime(2024, 6, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 28, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2219), new DateTime(2024, 6, 26, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 2, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2222), new DateTime(2024, 6, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2225), new DateTime(2024, 7, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2227), new DateTime(2024, 6, 16, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2230), new DateTime(2024, 7, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2229) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 22, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2232), new DateTime(2024, 6, 21, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 27, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2235), new DateTime(2024, 7, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2235) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 2, 1, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 6, 26, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(2237) });

            migrationBuilder.InsertData(
                table: "SoilQualitys",
                columns: new[] { "Id", "Chlorophyll", "FieldId", "InfoTime", "Iron", "Nitrate", "Oxygen", "PH", "Phyto", "Phytoplankton", "Salinity", "Silicate", "SoilMoisture", "SoilMoisture100cm", "SoilMoisture10cm", "SoilMoisture40cm", "SoilTemperature", "SoilTemperature100cm", "SoilTemperature10cm", "SoilTemperature40cm" },
                values: new object[,]
                {
                    { 1, 0.1f, 3, new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1733), 0.2f, 0.3f, 0.5f, 7f, 0.4f, 0.6f, 0.8f, 0.7f, 50, 80, 60, 70, 25, 28, 26, 27 },
                    { 2, 0.2f, 5, new DateTime(2024, 5, 12, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1757), 0.3f, 0.4f, 0.6f, 7.1f, 0.5f, 0.7f, 0.9f, 0.8f, 55, 85, 65, 75, 26, 29, 27, 28 },
                    { 3, 0.15f, 6, new DateTime(2024, 5, 11, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1761), 0.25f, 0.35f, 0.55f, 7.2f, 0.45f, 0.65f, 0.85f, 0.75f, 52, 82, 62, 72, 24, 27, 25, 26 },
                    { 4, 0.12f, 7, new DateTime(2024, 5, 10, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1770), 0.22f, 0.32f, 0.52f, 7.3f, 0.42f, 0.62f, 0.82f, 0.72f, 53, 83, 63, 73, 23, 26, 24, 25 },
                    { 5, 0.11f, 8, new DateTime(2024, 5, 9, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1773), 0.21f, 0.31f, 0.51f, 7.4f, 0.41f, 0.61f, 0.81f, 0.71f, 54, 84, 64, 74, 22, 25, 23, 24 },
                    { 6, 0.13f, 9, new DateTime(2024, 5, 8, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1777), 0.23f, 0.33f, 0.53f, 7.5f, 0.43f, 0.63f, 0.83f, 0.73f, 56, 86, 66, 76, 21, 24, 22, 23 },
                    { 7, 0.14f, 10, new DateTime(2024, 5, 7, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1780), 0.24f, 0.34f, 0.54f, 7.6f, 0.44f, 0.64f, 0.84f, 0.74f, 57, 87, 67, 77, 20, 23, 21, 22 },
                    { 8, 0.16f, 11, new DateTime(2024, 5, 6, 14, 28, 54, 683, DateTimeKind.Local).AddTicks(1783), 0.26f, 0.36f, 0.56f, 7.7f, 0.46f, 0.66f, 0.86f, 0.76f, 58, 88, 68, 78, 19, 22, 20, 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoilQualitys_FieldId",
                table: "SoilQualitys",
                column: "FieldId",
                unique: true,
                filter: "[FieldId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoilQualitys");

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 4, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7723), new DateTime(2024, 4, 6, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7727), new DateTime(2024, 3, 22, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 14, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7730), new DateTime(2024, 4, 16, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7729) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 19, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7733), new DateTime(2024, 4, 1, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 13, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7735), new DateTime(2024, 4, 26, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7738), new DateTime(2024, 4, 11, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7737) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7740), new DateTime(2024, 5, 1, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 28, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7743), new DateTime(2024, 4, 16, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7742) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 3, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7746), new DateTime(2024, 5, 11, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7745) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 8, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7748), new DateTime(2024, 4, 26, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 13, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7751), new DateTime(2024, 5, 16, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7753), new DateTime(2024, 5, 1, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 23, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7756), new DateTime(2024, 5, 21, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 28, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7758), new DateTime(2024, 5, 6, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7758) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7761), new DateTime(2024, 5, 26, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 7, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7764), new DateTime(2024, 5, 11, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7763) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 12, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7766), new DateTime(2024, 5, 31, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7765) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 17, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7770), new DateTime(2024, 5, 16, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7772), new DateTime(2024, 6, 5, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 27, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7775), new DateTime(2024, 5, 21, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7777), new DateTime(2024, 6, 10, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7781), new DateTime(2024, 5, 26, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 22, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7783), new DateTime(2024, 6, 20, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 27, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7786), new DateTime(2024, 6, 5, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7788), new DateTime(2024, 6, 25, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 6, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7791), new DateTime(2024, 6, 10, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 11, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7794), new DateTime(2024, 6, 30, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 16, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7838), new DateTime(2024, 6, 15, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7837) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 21, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7841), new DateTime(2024, 7, 5, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 26, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7843), new DateTime(2024, 6, 20, 15, 32, 58, 852, DateTimeKind.Local).AddTicks(7843) });
        }
    }
}
