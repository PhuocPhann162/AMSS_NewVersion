﻿using AMSS.Models;
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
        protected Guid AuthenticatedUserId
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                var userId = identity!.Claims
                    .First(x => x.Type == ClaimTypes.NameIdentifier)
                    .Value;

                return new Guid(userId);
            }
        }

        // protected Guid? TenantId
        // {
        //     get
        //     {
        //         var identity = HttpContext.User.Identity as ClaimsIdentity;
        //         var tenantId = identity?.Claims.First(x => x.Type == JwtCustomClaimNames.TenantId).Value;
        //
        //         if (Guid.TryParse(tenantId, out var tenantIdGuid))
        //         {
        //             return tenantIdGuid;
        //         }
        //
        //         return null;
        //     }
        // }
        protected IActionResult ProcessResponseMessage<TU>(APIResponse<TU> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.Unauthorized => Unauthorized(response),
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
