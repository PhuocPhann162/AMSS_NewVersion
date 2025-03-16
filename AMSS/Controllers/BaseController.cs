using AMSS.Entities;
using AMSS.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Security.Claims;

namespace AMSS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController<T> : ControllerBase
    {
        private ILogger<T> _logger;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected Guid AuthenticatedUserId
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                var userId = identity!.Claims
                    .First(x => x.Type == SD.ClaimType_Id)
                    .Value;

                return new Guid(userId);
            }
        }

        protected IActionResult ProcessResponseMessage<TU>(APIResponse<TU> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.Unauthorized => Unauthorized(response),
                HttpStatusCode.Created => Ok(response),
                HttpStatusCode.Conflict => Conflict(response),
                HttpStatusCode.NotFound => NotFound(response),
                HttpStatusCode.Forbidden => BadRequest(response),
                HttpStatusCode.BadRequest => BadRequest(response),
                _ => StatusCode(500, response)
            };
        }

        protected string AccessToken
        {
            get
            {
                return Request.Headers[HeaderNames.Authorization];
            }
        }
        protected Guid ActiveAccountId
        {
            get
            {
                if (!HttpContext.Request.Headers.TryGetValue("Accept-Account", out var header))
                {
                    return Guid.Empty;
                }
                if (!header.Any() || !Guid.TryParse(header.ToString(), out var activeAccountId))
                {
                    return Guid.Empty;
                }

                return activeAccountId;
            }
        }
    }
}
