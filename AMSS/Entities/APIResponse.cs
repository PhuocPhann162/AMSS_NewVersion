using System.Net;

namespace AMSS.Entities
{
    public class APIResponse<T>
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string SuccessMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public object Pagination { get; set; }
    }
}
