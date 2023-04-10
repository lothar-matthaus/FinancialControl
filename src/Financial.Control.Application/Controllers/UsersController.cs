using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Application.Models.Users.Response.Get;
using Financial.Control.Application.Models.Users.Response.Update;
using Financial.Control.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediatR, IApplication application) : base(mediatR, application)
        {
        }

        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="201">O usuário foi cadastrado com sucesso.</response>
        /// <response code="409">O usuário já existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPost]
        public async Task<UserCreateResponse> CreateUser([FromQuery] UserCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza os dados do usuário logado.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">O usuário foi atualizado com sucesso.</response>
        /// <response code="404">O usuário não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPut]
        [Authorize]
        public async Task<UserUpdateResponse> UpdateUser([FromQuery] UserUpdateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Retorna os dados do usuário que está logado.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Quando o usuário é encontrado e seus dados são retornados.</response>
        /// <response code="404">O usuário não foi encontrado.</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        [Authorize]
        public async Task<UserGetResponse> GetUser()
        {
            UserGetRequest request = UserGetRequest.Create();
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
