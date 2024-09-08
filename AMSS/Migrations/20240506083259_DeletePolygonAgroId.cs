using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class DeletePolygonAgroId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolygonAgroId",
                table: "PolygonApps");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
