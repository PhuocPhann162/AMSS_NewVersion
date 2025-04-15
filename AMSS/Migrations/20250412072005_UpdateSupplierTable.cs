using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Suppliers",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Suppliers",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Suppliers",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceName",
                table: "Suppliers",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierRole",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Crops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crops_SupplierId",
                table: "Crops",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Suppliers_SupplierId",
                table: "Crops",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Suppliers_SupplierId",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_SupplierId",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProvinceName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierRole",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Crops");
        }
    }
}
