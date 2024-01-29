using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator? _mediator;
        protected IMediator? Mediator
        {
            get
            {
                return _mediator;
            }
        }

        protected BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _mediator = httpContextAccessor.HttpContext?.RequestServices.GetService<IMediator?>();
        }
    }
}
