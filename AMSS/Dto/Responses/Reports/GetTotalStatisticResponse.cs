namespace AMSS.Dto.Responses.Reports
{
    public class GetTotalStatisticResponse
    {
        public TotalProducts TotalProducts { get; set; }
        public TotalUsers TotalUsers { get; set; }
        public TotalRevenue TotalRevenue { get; set; }
        public TotalOrders TotalOrders { get; set; }
    }

    public class TotalBase
    {
        public decimal Total { get; set; }
        public decimal GrowthRate { get; set; }
    }

    public class TotalProducts : TotalBase
    {

    }

    public class TotalUsers : TotalBase
    {

    }

    public class TotalRevenue : TotalBase
    {

    }

    public class TotalOrders
    {
        public int TotalDelivered { get; set; }
        public int TotalCancelled { get; set; }
    }
}
