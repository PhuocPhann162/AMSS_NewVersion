using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicImageIdToCropTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicImageId",
                schema: "Novaris",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicImageId",
                schema: "Novaris",
                table: "Crops");
        }
    }
}
