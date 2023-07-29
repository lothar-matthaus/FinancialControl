using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Application.Models.Cards.Response.Delete;
using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Application.Models.Cards.Response.List;
using Financial.Control.Application.Models.Cards.Response.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CardsController : FinancialControlController
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
        [HttpPost]

        public async Task<CardCreateResponse> Post([FromBody] CardCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza um cartão existente;
        /// </summary>
        /// <response code="200">O cartão foi atualizado com sucesso.</response>
        /// <response code="400">O cartão não existe foi encontrado no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPatch("{id}")]
        public async Task<CardUpdateResponse> Patch([FromRoute] long id, [FromBody] CardUpdateRequest request)
        {
            request.SetRequestId(id);
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Remove um cartão existente;
        /// </summary>
        /// <param name="id">Id do cartão a ser removido</param>
        /// <response code="200">O cartão foi removido com sucesso.</response>
        /// <response code="400">O cartão não existe foi encontrado no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<CardDeleteResponse> Delete([FromRoute] long id)
        {
            CardDeleteRequest request = CardDeleteRequest.Create(id);
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Coleta dados de um cartão existente;
        /// </summary>
        /// <param name="id">Id do cartão a ter seus dados coletado</param>
        /// <response code="200" >O cartão foi encontrado com sucesso.</response>
        /// <response code="400">O cartão não existe foi encontrado no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<CardGetResponse> Get([FromRoute] long id)
        {
            CardGetRequest request = CardGetRequest.Create(id);
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Retorna todos os cartões de um usuário;
        /// </summary>
        /// <response code="200" >O cartão foi encontrado com sucesso.</response>
        /// <response code="400">O cartão não existe foi encontrado no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        public async Task<CardListResponse> Get()
        {
            CardListRequest request = new CardListRequest();
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
