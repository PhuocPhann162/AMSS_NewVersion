using AMSS.Dto.Requests.Reports;
using AMSS.Dto.Responses.Reports;
using AMSS.Entities;
using AMSS.Models.OrderHeaders;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class ReportService : BaseService, IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<GetRevenueResponse>> GetRevenueAsync(GetRevenueRequest request)
        {
            List<OrderHeader> lstOrders = await _unitOfWork.OrderHeaderRepository.GetAllAsync();
            var revenueStatisticDTO = new GetRevenueResponse();
            if (request.Type == "daily")
            {
                var daysInMonth = DateTime.DaysInMonth(request.Year, request.Month);
                revenueStatisticDTO = new()
                {
                    DaysInMonth = daysInMonth,
                    Label = "Daily Revenue Statistic",
                    RevenueData = new(),
                };

                for (int i = 1; i <= daysInMonth; i++)
                {
                    var currentDate = new DateTime(request.Year, request.Month, i);
                    IEnumerable<OrderHeader> ordersFromDb = lstOrders.Where(u => u.OrderDate.Date == currentDate.Date);
                    if (ordersFromDb.Count() > 0)
                    {
                        decimal totalForDay = ordersFromDb.Sum(o => o.OrderTotal - o.DiscountAmount);
                        revenueStatisticDTO.RevenueData.Add(totalForDay);
                    }
                    else
                    {
                        revenueStatisticDTO.RevenueData.Add(0);
                    }
                }

                return BuildSuccessResponseMessage(revenueStatisticDTO);
            }
            else if (request.Type == "monthly")
            {
                revenueStatisticDTO = new()
                {
                    Label = "Monthly Revenue Statistic",
                    RevenueData = new(),
                };

                for (int i = 1; i <= 12; i++)
                {
                    var ordersFromDb = lstOrders.Where(u => u.OrderDate.Date.Month == i && u.OrderDate.Date.Year == request.Year);
                    if (ordersFromDb.Count() > 0)
                    {
                        decimal totalForMonth = ordersFromDb.Sum(o => o.OrderTotal - o.DiscountAmount);
                        revenueStatisticDTO.RevenueData.Add(totalForMonth);
                    }
                    else
                    {
                        revenueStatisticDTO.RevenueData.Add(0);
                    }
                }
                return BuildSuccessResponseMessage(revenueStatisticDTO);
            }
            else if (request.Type == "yearly" && request.EndYear != 0)
            {
                revenueStatisticDTO = new()
                {
                    Label = "Yearly Revenue Statistic",
                    RevenueData = new(),
                };

                for (int i = request.Year; i <= request.EndYear; i++)
                {
                    var ordersFromDb = lstOrders.Where(u => u.OrderDate.Date.Year == i);
                    if (ordersFromDb.Count() > 0)
                    {
                        decimal totalForYear = ordersFromDb.Sum(o => o.OrderTotal - o.DiscountAmount);
                        revenueStatisticDTO.RevenueData.Add(totalForYear);
                    }
                    else
                    {
                        revenueStatisticDTO.RevenueData.Add(0);
                    }
                }
                return BuildSuccessResponseMessage(revenueStatisticDTO);
            }
            return BuildSuccessResponseMessage(revenueStatisticDTO);
        }

        public async Task<APIResponse<GetOrderStatisticResponse>> GetOrderStatisticAsync(GetRevenueRequest request)
        {
            var lstOrders = await _unitOfWork.OrderHeaderRepository.GetAllAsync();
            var ordersStatisticDTO = new GetOrderStatisticResponse();
            if (request.Type == "daily")
            {
                var daysInMonth = DateTime.DaysInMonth(request.Year, request.Month);
                ordersStatisticDTO = new()
                {
                    DaysInMonth = daysInMonth,
                    Label = "Daily Number Of Orders Statistic",
                    OrdersData = new(),
                };

                for (int i = 1; i <= daysInMonth; i++)
                {
                    var currentDate = new DateTime(request.Year, request.Month, i);
                    IEnumerable<OrderHeader> ordersFromDb = lstOrders.Where(u => u.OrderDate.Date == currentDate.Date);
                    if (ordersFromDb.Count() > 0)
                    {
                        ordersStatisticDTO.OrdersData.Add(ordersFromDb.Count());
                    }
                    else
                    {
                        ordersStatisticDTO.OrdersData.Add(0);
                    }
                }
                return BuildSuccessResponseMessage(ordersStatisticDTO);
            }
            else if (request.Type == "monthly")
            {
                ordersStatisticDTO = new()
                {
                    Label = "Monthly Number Of Orders Statistic",
                    OrdersData = new(),
                };

                for (int i = 1; i <= 12; i++)
                {
                    var ordersFromDb = lstOrders.Where(u => u.OrderDate.Date.Month == i && u.OrderDate.Date.Year == request.Year);
                    if (ordersFromDb.Count() > 0)
                    {
                        ordersStatisticDTO.OrdersData.Add(ordersFromDb.Count());
                    }
                    else
                    {
                        ordersStatisticDTO.OrdersData.Add(0);
                    }
                }
                return BuildSuccessResponseMessage(ordersStatisticDTO);
            }
            else if (request.Type == "yearly" && request.EndYear > 0)
            {
                ordersStatisticDTO = new()
                {
                    Label = "Yearly Number Of Orders Statistic",
                    OrdersData = new(),
                };

                for (int i = request.Year; i <= request.EndYear; i++)
                {
                    var ordersFromDb = lstOrders.Where(u => u.OrderDate.Date.Year == i);
                    if (ordersFromDb.Count() > 0)
                    {
                        ordersStatisticDTO.OrdersData.Add(ordersFromDb.Count());
                    }
                    else
                    {
                        ordersStatisticDTO.OrdersData.Add(0);
                    }
                }
                return BuildSuccessResponseMessage(ordersStatisticDTO);
            }

            return BuildSuccessResponseMessage(ordersStatisticDTO);
        }
    }
}