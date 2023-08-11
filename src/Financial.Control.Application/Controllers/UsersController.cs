using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Application.Models.Users.Response.Get;
using Financial.Control.Application.Models.Users.Response.Update.Password;
using Financial.Control.Application.Models.Users.Response.Update.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : FinancialControlController
    {
        public UsersController(IMediator mediatR) : base(mediatR)
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
        public async Task<UserCreateResponse> CreateUser([FromBody] UserCreateRequest request)
        {
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza os dados do usuário logado.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">O usuário foi atualizado com sucesso.</response>
        /// <response code="400">O usuário não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPatch]
        [Authorize]
        public async Task<UserUpdateResponse> UpdateUser([FromBody] UserUpdateRequest request)
        {
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Busca os dados do usuário que está logado.
        /// </summary>
        /// <response code="200">O usuário foi encontrado com sucesso.</response>
        /// <response code="400">O usuário não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        [Authorize]
        public async Task<UserGetResponse> GetUser()
        {
            UserGetRequest request = UserGetRequest.Create();
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza a senha do usuário que está logado.
        /// </summary>
        /// <response code="200">A senha foi atualizada com sucesso.</response>
        /// <response code="400">O usu[ario não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPatch("Password")]
        [Authorize]
        public async Task<UserUpdatePasswordResponse> UpdatePassword([FromBody] UserUpdatePasswordRequest request)
        {
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
