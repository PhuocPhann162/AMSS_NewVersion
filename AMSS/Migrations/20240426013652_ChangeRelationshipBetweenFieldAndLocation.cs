using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipBetweenFieldAndLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Fields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Fields_LocationId",
                table: "Fields",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Locations_LocationId",
                table: "Fields",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Locations_LocationId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_LocationId",
                table: "Fields");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6380), new DateTime(2024, 3, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 26, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6385), new DateTime(2024, 3, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6384) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 7, 31, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6388), new DateTime(2024, 4, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6387) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 5, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 3, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 8, 30, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6393), new DateTime(2024, 4, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6396), new DateTime(2024, 3, 28, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6396) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 9, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6399), new DateTime(2024, 4, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6398) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 14, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 4, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6401) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 19, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6404), new DateTime(2024, 4, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6407), new DateTime(2024, 4, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 9, 29, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6410), new DateTime(2024, 5, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 4, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6412), new DateTime(2024, 4, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 9, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6415), new DateTime(2024, 5, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 14, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6418), new DateTime(2024, 4, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6417) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 19, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6421), new DateTime(2024, 5, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 24, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6424), new DateTime(2024, 4, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6427), new DateTime(2024, 5, 17, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6429), new DateTime(2024, 5, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6428) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6432), new DateTime(2024, 5, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6435), new DateTime(2024, 5, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6439), new DateTime(2024, 5, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6439) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6442), new DateTime(2024, 5, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 8, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6444), new DateTime(2024, 6, 6, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 13, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 5, 22, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 18, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6450), new DateTime(2024, 6, 11, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6449) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 23, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6453), new DateTime(2024, 5, 27, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2024, 12, 28, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6455), new DateTime(2024, 6, 16, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 2, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6482), new DateTime(2024, 6, 1, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 7, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6485), new DateTime(2024, 6, 21, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedDate", "PlantedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6487), new DateTime(2024, 6, 6, 22, 14, 17, 667, DateTimeKind.Local).AddTicks(6487) });
        }
    }
}
