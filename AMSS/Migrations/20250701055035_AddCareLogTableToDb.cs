using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddCareLogTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carelogs",
                schema: "Novaris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CropId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carelogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carelogs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Novaris",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carelogs_Crops_CropId",
                        column: x => x.CropId,
                        principalSchema: "Novaris",
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carelogs_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "Novaris",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carelogs_CreatedById",
                schema: "Novaris",
                table: "Carelogs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carelogs_CropId",
                schema: "Novaris",
                table: "Carelogs",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_Carelogs_FieldId",
                schema: "Novaris",
                table: "Carelogs",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carelogs",
                schema: "Novaris");
        }
    }
}
