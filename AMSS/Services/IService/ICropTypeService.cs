using AMSS.Models;
using AMSS.Models.Dto.CropType;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface ICropTypeService
    {
        Task<APIResponse<IEnumerable<CropTypeDto>>> GetAllCropTypesAsync(string? searchString, int? pageNumber, int? pageSize);
        Task<APIResponse<CropTypeDto>> CreateCropTypeAsync(CreateCropTypeDto createCropTypeDto);

    }
}
