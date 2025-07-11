﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldCropsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Novaris",
                table: "FieldCrops",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Novaris",
                table: "FieldCrops",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Novaris",
                table: "FieldCrops");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "Novaris",
                table: "FieldCrops");
        }
    }
}
