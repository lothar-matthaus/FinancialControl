using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response;
using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : BaseController
    {
        public CardsController(IMediator mediatR) : base(mediatR)
        {
        }

        /// <summary>
        /// Cria um novo cartão.
        /// </summary>
        /// <response code="201">O cartão foi criado com sucesso.</response>
        /// <response code="409">O cartão já existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpPost]
        [Authorize]
        public async Task<CardCreateResponse> CreateCard([FromQuery] CardCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
