using AMSS.Dto.Requests.Reports;
using AMSS.Dto.Responses.Reports;
using AMSS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IReportService
    {
        Task<APIResponse<GetRevenueResponse>> GetRevenueAsync(GetRevenueRequest request);
        Task<APIResponse<GetOrderStatisticResponse>> GetOrderStatisticAsync(GetRevenueRequest request);
        Task<APIResponse<GetTotalStatisticResponse>> GetToTalStatisticAsync(GetTotalStatisticRequest request);
    }
}
