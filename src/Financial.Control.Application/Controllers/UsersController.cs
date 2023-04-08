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

        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="201">O usuário foi cadastrado com sucesso.</response>
        /// <response code="409">O usuário já existe no sistema</response>
        [HttpPost]
        public async Task<UserCreateResponse> Post([FromQuery] UserCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
