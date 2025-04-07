using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAddressAndUpdateProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_UserId1",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "OrderHeaders",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrderHeaders",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeaders_UserId1",
                table: "OrderHeaders",
                newName: "IX_OrderHeaders_ApplicationUserId1");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "Coupons",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_LocationId",
                table: "OrderHeaders",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId1",
                table: "OrderHeaders",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Locations_LocationId",
                table: "OrderHeaders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId1",
                table: "OrderHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Locations_LocationId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_LocationId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "OrderHeaders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "OrderHeaders",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeaders_ApplicationUserId1",
                table: "OrderHeaders",
                newName: "IX_OrderHeaders_UserId1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "Coupons",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_UserId1",
                table: "OrderHeaders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
