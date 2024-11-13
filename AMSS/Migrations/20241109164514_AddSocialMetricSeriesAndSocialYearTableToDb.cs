using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddSocialMetricSeriesAndSocialYearTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeriesMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeriesMetricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryContinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMetrics_CountryContinents_CountryContinentId",
                        column: x => x.CountryContinentId,
                        principalTable: "CountryContinents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMetrics_SeriesMetrics_SeriesMetricId",
                        column: x => x.SeriesMetricId,
                        principalTable: "SeriesMetrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialMetricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialYears_SocialMetrics_SocialMetricId",
                        column: x => x.SocialMetricId,
                        principalTable: "SocialMetrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMetrics_CountryContinentId",
                table: "SocialMetrics",
                column: "CountryContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMetrics_SeriesMetricId",
                table: "SocialMetrics",
                column: "SeriesMetricId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialYears_SocialMetricId",
                table: "SocialYears",
                column: "SocialMetricId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialYears");

            migrationBuilder.DropTable(
                name: "SocialMetrics");

            migrationBuilder.DropTable(
                name: "SeriesMetrics");
        }
    }
}
