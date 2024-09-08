using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddPolygonAgroIdToPolygonAppTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PolygonAgroId",
                table: "PolygonApps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 3, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5556), new DateTime(2024, 4, 5, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 8, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5561), new DateTime(2024, 3, 21, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 13, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5564), new DateTime(2024, 4, 15, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 18, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5608), new DateTime(2024, 3, 31, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5613), new DateTime(2024, 4, 25, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 17, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5616), new DateTime(2024, 4, 10, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5615) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 22, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5619), new DateTime(2024, 4, 30, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5618) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 27, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5621), new DateTime(2024, 4, 15, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5621) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5624), new DateTime(2024, 5, 10, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5623) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5628), new DateTime(2024, 4, 25, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5627) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 12, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5630), new DateTime(2024, 5, 15, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 17, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5633), new DateTime(2024, 4, 30, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 22, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5636), new DateTime(2024, 5, 20, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 27, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5639), new DateTime(2024, 5, 5, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5639) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 1, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5642), new DateTime(2024, 5, 25, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5645), new DateTime(2024, 5, 10, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5644) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 11, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5647), new DateTime(2024, 5, 30, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 16, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5650), new DateTime(2024, 5, 15, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5649) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 21, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5652), new DateTime(2024, 6, 4, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5652) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5655), new DateTime(2024, 5, 20, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5654) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5658), new DateTime(2024, 6, 9, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 6, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5660), new DateTime(2024, 5, 25, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 21, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5664), new DateTime(2024, 6, 19, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 26, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5667), new DateTime(2024, 6, 4, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5666) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 31, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5670), new DateTime(2024, 6, 24, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 5, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5672), new DateTime(2024, 6, 9, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 10, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5676), new DateTime(2024, 6, 29, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5674) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 15, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5679), new DateTime(2024, 6, 14, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5678) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5682), new DateTime(2024, 7, 4, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5681) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 25, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5684), new DateTime(2024, 6, 19, 22, 18, 8, 903, DateTimeKind.Local).AddTicks(5684) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolygonAgroId",
                table: "PolygonApps");

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9275), new DateTime(2024, 3, 27, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 30, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9278), new DateTime(2024, 3, 12, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 4, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9281), new DateTime(2024, 4, 6, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9284), new DateTime(2024, 3, 22, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9283) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 3, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9287), new DateTime(2024, 4, 16, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 8, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9289), new DateTime(2024, 4, 1, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 13, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9292), new DateTime(2024, 4, 21, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9294), new DateTime(2024, 4, 6, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9297), new DateTime(2024, 5, 1, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 28, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9300), new DateTime(2024, 4, 16, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 3, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9302), new DateTime(2024, 5, 6, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9302) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 8, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9305), new DateTime(2024, 4, 21, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 13, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9308), new DateTime(2024, 5, 11, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9311), new DateTime(2024, 4, 26, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 23, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9313), new DateTime(2024, 5, 16, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 28, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9317), new DateTime(2024, 5, 1, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9320), new DateTime(2024, 5, 21, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 7, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9322), new DateTime(2024, 5, 6, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9322) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 12, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9325), new DateTime(2024, 5, 26, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 17, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9327), new DateTime(2024, 5, 11, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9330), new DateTime(2024, 5, 31, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9329) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 27, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9332), new DateTime(2024, 5, 16, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9332) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 12, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 6, 10, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9334) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 17, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9337), new DateTime(2024, 5, 26, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 22, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9344), new DateTime(2024, 6, 15, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 27, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9347), new DateTime(2024, 5, 31, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9349), new DateTime(2024, 6, 20, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9348) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 6, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9352), new DateTime(2024, 6, 5, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 11, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9354), new DateTime(2024, 6, 25, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9353) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 16, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9357), new DateTime(2024, 6, 10, 8, 36, 51, 999, DateTimeKind.Local).AddTicks(9356) });
        }
    }
}
