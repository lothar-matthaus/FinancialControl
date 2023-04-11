using Financial.Control.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediatR;

        public BaseController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
    }
}
