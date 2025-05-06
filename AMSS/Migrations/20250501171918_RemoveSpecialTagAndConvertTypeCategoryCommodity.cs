using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSpecialTagAndConvertTypeCategoryCommodity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialTag",
                schema: "Novaris",
                table: "Commodities");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "Novaris",
                table: "Commodities",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "Novaris",
                table: "Commodities",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "SpecialTag",
                schema: "Novaris",
                table: "Commodities",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
