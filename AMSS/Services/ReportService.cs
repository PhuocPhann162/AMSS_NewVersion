using AMSS.Dto.Requests.Reports;
using AMSS.Dto.Responses.Reports;
using AMSS.Entities;
using AMSS.Enums;
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

        public async Task<APIResponse<GetTotalStatisticResponse>> GetToTalStatisticAsync(GetTotalStatisticRequest request)
        {
            var response = new GetTotalStatisticResponse();

            var commodities = await _unitOfWork.CommodityRepository.GetAllAsync();
            var orders = await _unitOfWork.OrderHeaderRepository.GetAllAsync();
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            bool hasDateFilter = request.StartDate != default && request.EndDate != default;
            var filteredCommodities = commodities;
            var filteredUsers = users;
            var filteredOrders = orders;

            if (hasDateFilter)
            {
                filteredCommodities = commodities.Where(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate).ToList();
                filteredUsers = users.Where(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate).ToList();
                filteredOrders = orders.Where(x => x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate).ToList();
            }

            int totalProducts = filteredCommodities.Count;
            int totalUsers = filteredUsers.Count;
            decimal totalRevenue = filteredOrders
                .Where(o => o.Status is not OrderStatus.Cancelled and not OrderStatus.Pending)
                .Sum(o => o.OrderTotal - o.DiscountAmount);
            int totalDelivered = filteredOrders.Count(o => o.Status is not OrderStatus.Cancelled and not OrderStatus.Pending);
            int totalCancelled = filteredOrders.Count(o => o.Status == OrderStatus.Cancelled);

            decimal productGrowth = 0, userGrowth = 0, revenueGrowth = 0;
            if (hasDateFilter)
            {
                var period = request.EndDate - request.StartDate;
                var prevStart = request.StartDate.AddDays(-period.TotalDays - 1); // -1 để không bị trùng ngày
                var prevEnd = request.StartDate.AddDays(-1);

                var prevCommodities = commodities.Where(x => x.CreatedAt >= prevStart && x.CreatedAt <= prevEnd).ToList();
                var prevUsers = users.Where(x => x.CreatedAt >= prevStart && x.CreatedAt <= prevEnd).ToList();
                var prevOrders = orders.Where(x => x.OrderDate >= prevStart && x.OrderDate <= prevEnd).ToList();

                productGrowth = prevCommodities.Count == 0 ? 0 : ((decimal)(totalProducts - prevCommodities.Count) / prevCommodities.Count) * 100;
                userGrowth = prevUsers.Count == 0 ? 0 : ((decimal)(totalUsers - prevUsers.Count) / prevUsers.Count) * 100;
                var prevRevenue = prevOrders
                    .Where(o => o.Status == OrderStatus.Delivered)
                    .Sum(o => o.OrderTotal - o.DiscountAmount);
                revenueGrowth = prevRevenue == 0 ? 0 : ((totalRevenue - prevRevenue) / prevRevenue) * 100;
            }

            response.TotalProducts = new TotalProducts
            {
                Total = totalProducts,
                GrowthRate = productGrowth
            };
            response.TotalUsers = new TotalUsers
            {
                Total = totalUsers,
                GrowthRate = userGrowth
            };
            response.TotalRevenue = new TotalRevenue
            {
                Total = totalRevenue,
                GrowthRate = revenueGrowth
            };
            response.TotalOrders = new TotalOrders
            {
                TotalDelivered = totalDelivered,
                TotalCancelled = totalCancelled
            };

            return BuildSuccessResponseMessage(response);
        }
    }
}