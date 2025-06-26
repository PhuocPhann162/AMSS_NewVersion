using AMSS.Dto.Requests.Reports;
using AMSS.Dto.Responses.Reports;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IReportService
    {
        Task<APIResponse<GetRevenueResponse>> GetRevenueAsync(GetRevenueRequest request);
        Task<APIResponse<GetOrderStatisticResponse>> GetOrderStatisticAsync(GetRevenueRequest request);
    }
}
