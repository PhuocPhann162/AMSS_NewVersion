namespace AMSS.Dto.Responses.Reports
{
    public class GetRevenueResponse
    {
        public int DaysInMonth { get; set; }
        public string Label { get; set; }
        public List<decimal> RevenueData { get; set; }
    }
}
