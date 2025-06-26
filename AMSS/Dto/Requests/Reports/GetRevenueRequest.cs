namespace AMSS.Dto.Requests.Reports
{
    public class GetRevenueRequest
    {
        public string Type { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int EndYear { get; set; }
    }
}
