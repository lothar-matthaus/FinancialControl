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
        public async Task<CardCreateResponse> CreateCard([FromBody] CardCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza um cartão existente;
        /// </summary>
        /// <response code="200">O cartão foi atualizado com sucesso.</response>
        /// <response code="404">O cartão não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPut]
        [Authorize]
        public async Task<CardUpdateResponse> UpdateCard([FromBody] CardUpdateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Remove um cartão existente;
        /// </summary>
        /// <param name="id">Id do cartão a ser removido</param>
        /// <response code="200" >O cartão foi removido com sucesso.</response>
        /// <response code="404">O cartão não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<CardDeleteResponse> RemoveCard([FromRoute] long id)
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
        /// <response code="404">O cartão não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<CardGetResponse> GetCard([FromRoute] long id)
        {
            CardGetRequest request = CardGetRequest.Create(id);
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Retorna todos os cartões de um usuário;
        /// </summary>
        /// <response code="200" >O cartão foi encontrado com sucesso.</response>
        /// <response code="404">O cartão não existe no sistema</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        [Authorize]
        [Route("List")]
        public async Task<CardListResponse> GetCardList()
        {
            CardListRequest request = CardListRequest.Create();
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
