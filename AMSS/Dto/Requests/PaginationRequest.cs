using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests
{
    public class PaginationRequest
    {
        public string OrderBy { get; set; }

        public ListSortDirection OrderByDirection { get; set; }

        public int CurrentPage { get; set; }

        public int Limit { get; set; }

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
