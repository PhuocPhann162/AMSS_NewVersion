using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddPropsToCropTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CropTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CropTypes",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 20, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7461), new DateTime(2024, 3, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7464), new DateTime(2024, 3, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 30, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7467), new DateTime(2024, 4, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7467) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 4, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 3, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7472), new DateTime(2024, 4, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 3, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7475), new DateTime(2024, 3, 27, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 8, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 4, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 13, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 4, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7481) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7484), new DateTime(2024, 4, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7486), new DateTime(2024, 4, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 28, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7489), new DateTime(2024, 5, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 3, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7491), new DateTime(2024, 4, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7491) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 8, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7494), new DateTime(2024, 5, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 4, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7499), new DateTime(2024, 5, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7498) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 23, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7502), new DateTime(2024, 4, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7501) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 28, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7504), new DateTime(2024, 5, 16, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7508), new DateTime(2024, 5, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7510), new DateTime(2024, 5, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 12, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7513), new DateTime(2024, 5, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7515), new DateTime(2024, 5, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7518), new DateTime(2024, 5, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7520), new DateTime(2024, 6, 5, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 12, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7523), new DateTime(2024, 5, 21, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 17, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7525), new DateTime(2024, 6, 10, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 22, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7528), new DateTime(2024, 5, 26, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 27, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7530), new DateTime(2024, 6, 15, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7532), new DateTime(2024, 5, 31, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 6, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7535), new DateTime(2024, 6, 20, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 11, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7537), new DateTime(2024, 6, 5, 22, 1, 5, 176, DateTimeKind.Local).AddTicks(7537) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CropTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CropTypes");

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 20, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2133), new DateTime(2024, 3, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2137), new DateTime(2024, 3, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2140), new DateTime(2024, 4, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 4, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2177), new DateTime(2024, 3, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2180), new DateTime(2024, 4, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 3, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2183), new DateTime(2024, 3, 27, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 8, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2186), new DateTime(2024, 4, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2185) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 13, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2189), new DateTime(2024, 4, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2188) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2192), new DateTime(2024, 4, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2195), new DateTime(2024, 4, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2194) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2197), new DateTime(2024, 5, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 3, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2200), new DateTime(2024, 4, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 8, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2203), new DateTime(2024, 5, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 13, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2206), new DateTime(2024, 4, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2209), new DateTime(2024, 5, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 23, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2212), new DateTime(2024, 4, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 28, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2215), new DateTime(2024, 5, 16, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2218), new DateTime(2024, 5, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2221), new DateTime(2024, 5, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 12, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 5, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2226), new DateTime(2024, 5, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2226) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2229), new DateTime(2024, 5, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2232), new DateTime(2024, 6, 5, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 12, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2235), new DateTime(2024, 5, 21, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2234) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 17, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 6, 10, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 22, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2240), new DateTime(2024, 5, 26, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 27, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2243), new DateTime(2024, 6, 15, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2246), new DateTime(2024, 5, 31, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 6, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2248), new DateTime(2024, 6, 20, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 11, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2251), new DateTime(2024, 6, 5, 20, 50, 38, 822, DateTimeKind.Local).AddTicks(2251) });
        }
    }
}
