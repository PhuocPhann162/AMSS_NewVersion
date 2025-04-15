using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }

        public PaginationResponse()
        {
        }

        public PaginationResponse(int currentPage, int limit, int totalRow, int totalPage)
        {
            CurrentPage = currentPage;
            Limit = limit;
            TotalRow = totalRow;
            TotalPage = totalPage;
        }
    }
}
