using AMSS.Dto.Crop;
using AMSS.Entities;

namespace AMSS.Services.IService.IGeneratePdf
{
    public interface IHarvestExportService
    {
        Task<APIResponse<string>> GenerateHarvestExportPdfAsync(HarvestExportData data);
    }
} 