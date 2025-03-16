using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses
{
    public class PaginationResponse<T>
    {
        [JsonPropertyName("Collection")]
        public IEnumerable<T> Collection { get; set; }
        [JsonPropertyName("CurrentPage")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("Limit")]
        public int Limit { get; set; }
        [JsonPropertyName("TotalRow")]
        public int TotalRow { get; set; }
        [JsonPropertyName("TotalPage")]
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
