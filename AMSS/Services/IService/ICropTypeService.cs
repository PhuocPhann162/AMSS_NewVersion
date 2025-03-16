using AMSS.Dto.CropType;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ICropTypeService
    {
        Task<APIResponse<IEnumerable<CropTypeDto>>> GetAllCropTypesAsync(string? searchString, int? pageNumber, int? pageSize);
        Task<APIResponse<CropTypeDto>> CreateCropTypeAsync(CreateCropTypeDto createCropTypeDto);

    }
}
