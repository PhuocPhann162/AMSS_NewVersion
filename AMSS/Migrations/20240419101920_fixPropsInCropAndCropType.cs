using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class fixPropsInCropAndCropType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_CropTypes_CropTypeId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Fields_FieldCropId",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "FieldCropId",
                table: "Crops",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_FieldCropId",
                table: "Crops",
                newName: "IX_Crops_FieldId");

            migrationBuilder.AlterColumn<int>(
                name: "CropTypeId",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_CropTypes_CropTypeId",
                table: "Crops",
                column: "CropTypeId",
                principalTable: "CropTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Fields_FieldId",
                table: "Crops",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_CropTypes_CropTypeId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Fields_FieldId",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Crops",
                newName: "FieldCropId");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_FieldId",
                table: "Crops",
                newName: "IX_Crops_FieldCropId");

            migrationBuilder.AlterColumn<int>(
                name: "CropTypeId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_CropTypes_CropTypeId",
                table: "Crops",
                column: "CropTypeId",
                principalTable: "CropTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Fields_FieldCropId",
                table: "Crops",
                column: "FieldCropId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
