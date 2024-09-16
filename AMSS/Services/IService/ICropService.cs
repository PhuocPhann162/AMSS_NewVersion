using AMSS.Models;
using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.FieldCrop;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface ICropService
    {
        Task<APIResponse<IEnumerable<CropDto>>> GetCropsAsync();
        Task<APIResponse<CropDto>> GetCropByIdAsync(string id);
        Task<APIResponse<IEnumerable<FieldCropDto>>> GetCropsByFieldIdAsync(string fieldId);
        Task<APIResponse<CropDto>> CreateCropAsync(CreateCropDto createCropDto);
        Task<APIResponse<CropDto>> UpdateCropAsync(string id, UpdateCropDto updateCropDto);
        Task<APIResponse<bool>> DeleteCropAsync(string id);
    }
}
