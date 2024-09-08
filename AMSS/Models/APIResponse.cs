using System.Net;

namespace AMSS.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? SuccessMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
