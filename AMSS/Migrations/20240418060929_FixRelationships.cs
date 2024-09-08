using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolygonApps_Farms_FarmId",
                table: "PolygonApps");

            migrationBuilder.DropForeignKey(
                name: "FK_PolygonApps_Fields_FieldId",
                table: "PolygonApps");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PolygonApps_PolygonAppId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_PolygonApps_FarmId",
                table: "PolygonApps");

            migrationBuilder.DropIndex(
                name: "IX_PolygonApps_FieldId",
                table: "PolygonApps");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "PolygonApps");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "PolygonApps");

            migrationBuilder.AlterColumn<int>(
                name: "PolygonAppId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PolygonAppId",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolygonAppId",
                table: "Farms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields",
                column: "PolygonAppId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms",
                column: "PolygonAppId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_PolygonApps_PolygonAppId",
                table: "Farms",
                column: "PolygonAppId",
                principalTable: "PolygonApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_PolygonApps_PolygonAppId",
                table: "Fields",
                column: "PolygonAppId",
                principalTable: "PolygonApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PolygonApps_PolygonAppId",
                table: "Positions",
                column: "PolygonAppId",
                principalTable: "PolygonApps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_PolygonApps_PolygonAppId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_PolygonApps_PolygonAppId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PolygonApps_PolygonAppId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Fields_PolygonAppId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Farms_PolygonAppId",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "PolygonAppId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "PolygonAppId",
                table: "Farms");

            migrationBuilder.AlterColumn<int>(
                name: "PolygonAppId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "PolygonApps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "PolygonApps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolygonApps_FarmId",
                table: "PolygonApps",
                column: "FarmId",
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonApps_FieldId",
                table: "PolygonApps",
                column: "FieldId",
                unique: true,
                filter: "[FieldId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PolygonApps_Farms_FarmId",
                table: "PolygonApps",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PolygonApps_Fields_FieldId",
                table: "PolygonApps",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PolygonApps_PolygonAppId",
                table: "Positions",
                column: "PolygonAppId",
                principalTable: "PolygonApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
