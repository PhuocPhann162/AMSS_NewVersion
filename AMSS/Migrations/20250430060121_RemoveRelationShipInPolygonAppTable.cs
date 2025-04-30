using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationShipInPolygonAppTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields",
                column: "PolygonAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms",
                column: "PolygonAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields",
                column: "PolygonAppId",
                unique: true,
                filter: "[PolygonAppId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms",
                column: "PolygonAppId",
                unique: true,
                filter: "[PolygonAppId] IS NOT NULL");
        }
    }
}
