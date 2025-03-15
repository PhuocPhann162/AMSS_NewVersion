using AMSS.Entities;
using AMSS.Services.IService;
using System.Net;

namespace AMSS.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse<T> BuildResponseMessage<T>(T data, bool isSuccess, HttpStatusCode statusCode, string message = "", List<string>? errorMessages = null, object? pagination = null)
        {
            return new APIResponse<T>
            {
                Result = data,
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                SuccessMessage = isSuccess ? message : null,
                ErrorMessages = errorMessages ?? new List<string>(), 
                Pagination = pagination,
            };
        }

        public APIResponse<T> BuildSuccessResponseMessage<T>(T data, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK, object? pagination = null)
        {
            return BuildResponseMessage(data, true, statusCode, message, null, pagination);
        }

        public APIResponse<T> BuildErrorResponseMessage<T>(string errorMessage, HttpStatusCode statusCode)
        {
            return BuildResponseMessage(default(T), false, statusCode, "", new List<string> { errorMessage })!;
        }
    }
}
