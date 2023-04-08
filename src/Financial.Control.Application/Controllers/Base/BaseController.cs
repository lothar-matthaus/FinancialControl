using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Models;
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
