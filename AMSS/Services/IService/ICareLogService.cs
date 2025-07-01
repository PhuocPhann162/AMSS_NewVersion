using AMSS.Dto.Requests.CareLogs;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Dto.CareLog;

namespace AMSS.Services.IService
{
    public interface ICareLogService
    {
        Task<APIResponse<PaginationResponse<CareLogDto>>> GetCareLogsAsync(Guid userId, GetCareLogsRequest request);
        Task<APIResponse<bool>> CreateCareLogAsync(Guid userId, CreateCareLogRequest request);
    }
}
