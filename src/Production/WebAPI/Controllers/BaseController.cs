using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected string? GetIpAddress()
        {
            if (Request.Headers.TryGetValue("X-Forwarded-For", out Microsoft.Extensions.Primitives.StringValues value)) return value;

            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        protected int GetUserIdFromRequest()
        {
            int userId = HttpContext.User.GetUserId();
            return userId;
        }

        protected string? getAccessTokenFromCookies()
        {
            return Request.Cookies["accessToken"];
        }
    }
}