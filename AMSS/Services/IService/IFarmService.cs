using AMSS.Dto.Farm;
using AMSS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IFarmService
    {
        Task<APIResponse<IEnumerable<FarmDto>>> GetAllFarmsAsync(string? searchString, int? pageNumber, int? pageSize);
        Task<APIResponse<FarmDto>> GetFarmByIdAsync(string id);
        Task<APIResponse<bool>> CreateFarmAsync(CreateFarmDto createFarmDto);
        Task<APIResponse<FarmDto>> UpdateFarmAsync(string id, FarmDto updateFarmDto);
        Task<APIResponse<bool>> DeleteFarmAsync(string id);
    }
}
