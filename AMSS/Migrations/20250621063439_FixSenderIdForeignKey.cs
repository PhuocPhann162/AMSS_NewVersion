using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class FixSenderIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_CreatedById1",
                schema: "Novaris",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_AspNetUsers_UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId1",
                schema: "Novaris",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId1",
                schema: "Novaris",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_ChatRoomUsers_UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_CreatedById1",
                schema: "Novaris",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                schema: "Novaris",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                schema: "Novaris",
                table: "ChatRooms");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                schema: "Novaris",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Novaris",
                table: "ChatRoomUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                schema: "Novaris",
                table: "ChatRooms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "Novaris",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_CreatedById",
                schema: "Novaris",
                table: "ChatRooms",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_CreatedById",
                schema: "Novaris",
                table: "ChatRooms",
                column: "CreatedById",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_AspNetUsers_UserId",
                schema: "Novaris",
                table: "ChatRoomUsers",
                column: "UserId",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                schema: "Novaris",
                table: "Messages",
                column: "SenderId",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_CreatedById",
                schema: "Novaris",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_AspNetUsers_UserId",
                schema: "Novaris",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                schema: "Novaris",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                schema: "Novaris",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_CreatedById",
                schema: "Novaris",
                table: "ChatRooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "SenderId",
                schema: "Novaris",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                schema: "Novaris",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Novaris",
                table: "ChatRoomUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                schema: "Novaris",
                table: "ChatRooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById1",
                schema: "Novaris",
                table: "ChatRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId1",
                schema: "Novaris",
                table: "Messages",
                column: "SenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUsers_UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_CreatedById1",
                schema: "Novaris",
                table: "ChatRooms",
                column: "CreatedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_CreatedById1",
                schema: "Novaris",
                table: "ChatRooms",
                column: "CreatedById1",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_AspNetUsers_UserId1",
                schema: "Novaris",
                table: "ChatRoomUsers",
                column: "UserId1",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId1",
                schema: "Novaris",
                table: "Messages",
                column: "SenderId1",
                principalSchema: "Novaris",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
