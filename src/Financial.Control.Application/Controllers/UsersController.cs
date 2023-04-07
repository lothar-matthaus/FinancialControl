using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediatR) : base(mediatR) { }

        [HttpPost]
        public Task<UserCreateResponse> Post([FromBody] UserCreateRequest request)
        {
            request.SetModelState(ModelState);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
