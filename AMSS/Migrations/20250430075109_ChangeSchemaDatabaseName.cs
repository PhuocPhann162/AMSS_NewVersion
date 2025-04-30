using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchemaDatabaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE [dbo].[PolygonApps]
                SET [UpdatedAt] = GETDATE()
            ");

            migrationBuilder.EnsureSchema(
                name: "Novaris");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Suppliers",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stocks",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "SoilQualitys",
                newName: "SoilQualitys",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "SocialYears",
                newName: "SocialYears",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "SocialMetrics",
                newName: "SocialMetrics",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCarts",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "SeriesMetrics",
                newName: "SeriesMetrics",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Provinces",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Positions",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "PolygonApps",
                newName: "PolygonApps",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "OrderHeaders",
                newName: "OrderHeaders",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetails",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Locations",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "Fields",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "FieldCrops",
                newName: "FieldCrops",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Farms",
                newName: "Farms",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "CropTypes",
                newName: "CropTypes",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Crops",
                newName: "Crops",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "Coupons",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "CountryContinents",
                newName: "CountryContinents",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "Commodities",
                newName: "Commodities",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItems",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Novaris");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Novaris");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Novaris",
                table: "PolygonApps",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Novaris",
                table: "PolygonApps",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "Novaris",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Stocks",
                schema: "Novaris",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "SoilQualitys",
                schema: "Novaris",
                newName: "SoilQualitys");

            migrationBuilder.RenameTable(
                name: "SocialYears",
                schema: "Novaris",
                newName: "SocialYears");

            migrationBuilder.RenameTable(
                name: "SocialMetrics",
                schema: "Novaris",
                newName: "SocialMetrics");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                schema: "Novaris",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "SeriesMetrics",
                schema: "Novaris",
                newName: "SeriesMetrics");

            migrationBuilder.RenameTable(
                name: "Provinces",
                schema: "Novaris",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "Positions",
                schema: "Novaris",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "PolygonApps",
                schema: "Novaris",
                newName: "PolygonApps");

            migrationBuilder.RenameTable(
                name: "OrderHeaders",
                schema: "Novaris",
                newName: "OrderHeaders");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "Novaris",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "Novaris",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Fields",
                schema: "Novaris",
                newName: "Fields");

            migrationBuilder.RenameTable(
                name: "FieldCrops",
                schema: "Novaris",
                newName: "FieldCrops");

            migrationBuilder.RenameTable(
                name: "Farms",
                schema: "Novaris",
                newName: "Farms");

            migrationBuilder.RenameTable(
                name: "CropTypes",
                schema: "Novaris",
                newName: "CropTypes");

            migrationBuilder.RenameTable(
                name: "Crops",
                schema: "Novaris",
                newName: "Crops");

            migrationBuilder.RenameTable(
                name: "Coupons",
                schema: "Novaris",
                newName: "Coupons");

            migrationBuilder.RenameTable(
                name: "CountryContinents",
                schema: "Novaris",
                newName: "CountryContinents");

            migrationBuilder.RenameTable(
                name: "Commodities",
                schema: "Novaris",
                newName: "Commodities");

            migrationBuilder.RenameTable(
                name: "CartItems",
                schema: "Novaris",
                newName: "CartItems");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Novaris",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Novaris",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Novaris",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Novaris",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Novaris",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Novaris",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Novaris",
                newName: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PolygonApps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PolygonApps",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
