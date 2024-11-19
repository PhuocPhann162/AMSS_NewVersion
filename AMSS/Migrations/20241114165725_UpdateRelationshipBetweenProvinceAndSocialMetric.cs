using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipBetweenProvinceAndSocialMetric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMetrics_CountryContinents_CountryContinentId",
                table: "SocialMetrics");

            migrationBuilder.RenameColumn(
                name: "CountryContinentId",
                table: "SocialMetrics",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMetrics_CountryContinentId",
                table: "SocialMetrics",
                newName: "IX_SocialMetrics_ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMetrics_Provinces_ProvinceId",
                table: "SocialMetrics",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMetrics_Provinces_ProvinceId",
                table: "SocialMetrics");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "SocialMetrics",
                newName: "CountryContinentId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMetrics_ProvinceId",
                table: "SocialMetrics",
                newName: "IX_SocialMetrics_CountryContinentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMetrics_CountryContinents_CountryContinentId",
                table: "SocialMetrics",
                column: "CountryContinentId",
                principalTable: "CountryContinents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
