using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests
{
    public class PaginationRequest
    {
        [JsonPropertyName("OrderBy")]
        public string OrderBy { get; set; }

        [JsonPropertyName("OrderByDirection")]
        public ListSortDirection OrderByDirection { get; set; }

        [JsonPropertyName("CurrentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("Limit")]
        public int Limit { get; set; }

        [JsonPropertyName("Search")]
        public string Search { get; set; }

        public void InitializeParams()
        {
            if (CurrentPage <= 0)
            {
                CurrentPage = 1;
            }

            if (Limit <= 0 || Limit > 100)
            {
                Limit = 100;
            }
        }

        public PaginationRequest()
        {
            InitializeParams();
        }
    }
}
