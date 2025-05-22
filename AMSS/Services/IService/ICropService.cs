using AMSS.Dto.Crop;
using AMSS.Dto.FieldCrop;
using AMSS.Dto.Requests.Crops;
using AMSS.Dto.Responses;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ICropService
    {
        Task<APIResponse<PaginationResponse<CropDto>>> GetPlantingCropsAsync(GetPlantingCropsRequest request);
        Task<APIResponse<CropDto>> GetCropByIdAsync(string id);
        Task<APIResponse<IEnumerable<FieldCropDto>>> GetCropsByFieldIdAsync(string fieldId);
        Task<APIResponse<bool>> AddPlantingCropsAsync(AddPlantingCropRequest addPlantingCropRequest);
        Task<APIResponse<bool>> CreateCropAsync(CreateCropDto createCropDto);
        Task<APIResponse<bool>> UpdateCropAsync(string id, UpdateCropDto updateCropDto);
        Task<APIResponse<bool>> DeleteCropAsync(string id);
        Task<APIResponse<bool>> RemovePlantingCropAsync(RemovePlantingCropRequest request);
    }
}
