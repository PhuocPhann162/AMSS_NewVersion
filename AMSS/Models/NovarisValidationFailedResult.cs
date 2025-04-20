using AMSS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace AMSS.Models
{
    public class NovarisValidationFailedResult : ObjectResult
    {
        public NovarisValidationFailedResult(ModelStateDictionary modelState) : base(FormatValidationErrors(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        private static APIResponse<bool> FormatValidationErrors(ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => new ValidationErrorField
                {
                    Field = e.Key,
                    Messages = e.Value.Errors.Select(er => er.ErrorMessage).ToList()
                }).ToList();
            var errorString = string.Join(", ", errors.Select(e =>
            $"{e.Field}: {string.Join(" | ", e.Messages)}"));

            return new APIResponse<bool>
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Result = false, 
                SuccessMessage = null,
                ErrorMessages = new List<string>() { "Validation failed for one or more fields.", { errorString } },
            };
        }
    }
}
