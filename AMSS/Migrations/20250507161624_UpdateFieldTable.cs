using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberObBeds",
                schema: "Novaris",
                table: "Fields",
                newName: "NumberOfBeds");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Novaris",
                table: "Fields",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Novaris",
                table: "Fields");

            migrationBuilder.RenameColumn(
                name: "NumberOfBeds",
                schema: "Novaris",
                table: "Fields",
                newName: "NumberObBeds");
        }
    }
}
