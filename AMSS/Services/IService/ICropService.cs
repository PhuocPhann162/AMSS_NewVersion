using AMSS.Dto.Crop;
using AMSS.Dto.FieldCrop;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ICropService
    {
        Task<APIResponse<IEnumerable<CropDto>>> GetCropsAsync();
        Task<APIResponse<CropDto>> GetCropByIdAsync(string id);
        Task<APIResponse<IEnumerable<FieldCropDto>>> GetCropsByFieldIdAsync(string fieldId);
        Task<APIResponse<bool>> CreateCropAsync(CreateCropDto createCropDto);
        Task<APIResponse<bool>> UpdateCropAsync(string id, UpdateCropDto updateCropDto);
        Task<APIResponse<bool>> DeleteCropAsync(string id);
    }
}
