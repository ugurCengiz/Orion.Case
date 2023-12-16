using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Orion.Case.API.Controllers
{
    public class BaseController:ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
