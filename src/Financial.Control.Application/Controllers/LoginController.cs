using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Logon.Commands;
using Financial.Control.Application.Models.Logon.Response;
using Financial.Control.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        public LoginController(IMediator mediatR, IApplication application) : base(mediatR, application) { }

        /// <summary>
        ///  Realiza o login no sistema e retorna um token de acesso.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="404">O usuário não foi encontrado.</response>
        [HttpPost]
        public Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            request.SetModelState(ModelState);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
