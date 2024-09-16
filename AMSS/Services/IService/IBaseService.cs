using AMSS.Models;
using System.Net;

namespace AMSS.Services.IService
{
    public interface IBaseService
    {
        APIResponse<T> BuildResponseMessage<T>(T data, bool isSuccess, HttpStatusCode statusCode, string message = "", List<string>? errorMessages = null, object? pagination = null);
        APIResponse<T> BuildSuccessResponseMessage<T>(T data, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK, object? pagination = null);
        APIResponse<T> BuildErrorResponseMessage<T>(string errorMessage, HttpStatusCode statusCode);
    }
}
