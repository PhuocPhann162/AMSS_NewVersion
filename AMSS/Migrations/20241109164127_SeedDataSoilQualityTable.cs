using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataSoilQualityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    IF NOT EXISTS (SELECT * FROM [AMSS_N].[dbo].[SoilQualitys]) 
                    BEGIN 
                        INSERT INTO dbo.SoilQualitys (
                            Id,
                            InfoTime,
                            Chlorophyll,
                            Iron,
                            Nitrate,
                            Phyto,
                            Oxygen,
                            PH,
                            Phytoplankton,
                            Silicate,
                            Salinity,
                            SoilMoisture,
                            SoilMoisture10cm,
                            SoilMoisture40cm,
                            SoilMoisture100cm,
                            SoilTemperature,
                            SoilTemperature10cm,
                            SoilTemperature40cm,
                            SoilTemperature100cm,
                            FieldId, 
                            CreatedAt, 
                            UpdatedAt
                        ) VALUES 
                            (NEWID(), GETDATE(), 0.1, 0.2, 0.3, 0.4, 0.5, 7.0, 0.6, 0.7, 0.8, 50, 60, 70, 80, 25, 26, 27, 28, '7176C04D-43F6-4320-ED93-08DCEB701330', GETDATE(), GETDATE()),
                            (NEWID(), GETDATE(), 0.2, 0.3, 0.4, 0.5, 0.6, 7.1, 0.7, 0.8, 0.9, 55, 65, 75, 85, 26, 27, 28, 29, 'D34DA732-B9D5-4706-3E95-08DCED2CF9C8', GETDATE(), GETDATE()),
                            (NEWID(), DATEADD(DAY, -1, GETDATE()), 0.15, 0.25, 0.35, 0.45, 0.55, 7.2, 0.65, 0.75, 0.85, 52, 62, 72, 82, 24, 25, 26, 27, 'BC0F6323-1D8B-4BF5-3E96-08DCED2CF9C8', GETDATE(), GETDATE()),
                            (NEWID(), DATEADD(DAY, -2, GETDATE()), 0.12, 0.22, 0.32, 0.42, 0.52, 7.3, 0.62, 0.72, 0.82, 53, 63, 73, 83, 23, 24, 25, 26, '69DC757D-B80E-4050-570F-08DCED37B71B', GETDATE(), GETDATE()),
                            (NEWID(), DATEADD(DAY, -3, GETDATE()), 0.11, 0.21, 0.31, 0.41, 0.51, 7.4, 0.61, 0.71, 0.81, 54, 64, 74, 84, 22, 23, 24, 25, 'DB366B32-D8B3-4EF1-5710-08DCED37B71B', GETDATE(), GETDATE()),
                            (NEWID(), DATEADD(DAY, -4, GETDATE()), 0.13, 0.23, 0.33, 0.43, 0.53, 7.5, 0.63, 0.73, 0.83, 56, 66, 76, 86, 21, 22, 23, 24, 'B88227E7-12C9-4741-5711-08DCED37B71B', GETDATE(), GETDATE());
                    END"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
