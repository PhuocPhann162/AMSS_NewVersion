namespace AMSS.Models
{
    public class PaginationResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }
        public int Skip { get; set; }
        public PaginationResult()
        {
            Data = Enumerable.Empty<T>();
        }
    }
}
