using AMSS.Models;
using AMSS.Models.Dto.Farm;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IFarmService
    {
        Task<APIResponse<IEnumerable<FarmDto>>> GetAllFarmsAsync(string? searchString, int? pageNumber, int? pageSize);
        Task<APIResponse<FarmDto>> GetFarmByIdAsync(string id);
        Task<APIResponse<FarmDto>> CreateFarmAsync(CreateFarmDto createFarmDto);
        Task<APIResponse<FarmDto>> UpdateFarmAsync(string id, FarmDto updateFarmDto);
        Task<APIResponse<bool>> DeleteFarmAsync(string id);
    }
}
