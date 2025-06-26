namespace AMSS.Dto.Responses.Reports
{
    public class GetOrderStatisticResponse
    {
        public int DaysInMonth { get; set; }
        public string Label { get; set; }
        public List<decimal> OrdersData { get; set; }
    }
}
