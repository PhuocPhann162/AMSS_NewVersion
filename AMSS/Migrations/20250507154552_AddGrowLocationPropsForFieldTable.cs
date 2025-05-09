using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddGrowLocationPropsForFieldTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BedLength",
                schema: "Novaris",
                table: "Fields",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BedWidth",
                schema: "Novaris",
                table: "Fields",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrazingRestDays",
                schema: "Novaris",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InternalId",
                schema: "Novaris",
                table: "Fields",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightProfile",
                schema: "Novaris",
                table: "Fields",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationType",
                schema: "Novaris",
                table: "Fields",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberObBeds",
                schema: "Novaris",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlantingFormat",
                schema: "Novaris",
                table: "Fields",
                type: "nvarchar(20)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedLength",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "BedWidth",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "GrazingRestDays",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "InternalId",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "LightProfile",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "LocationType",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "NumberObBeds",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "PlantingFormat",
                schema: "Novaris",
                table: "Fields");
        }
    }
}
