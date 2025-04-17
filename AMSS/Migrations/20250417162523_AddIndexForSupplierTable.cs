using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexForSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ContactName",
                table: "Suppliers",
                column: "ContactName");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryCode",
                table: "Suppliers",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name",
                table: "Suppliers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierRole",
                table: "Suppliers",
                column: "SupplierRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ContactName",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CountryCode",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_Name",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierRole",
                table: "Suppliers");
        }
    }
}
