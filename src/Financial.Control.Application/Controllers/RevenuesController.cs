using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Queries;
using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Application.Models.Revenues.Response.Delete;
using Financial.Control.Application.Models.Revenues.Response.Get;
using Financial.Control.Application.Models.Revenues.Response.List;
using Financial.Control.Application.Models.Revenues.Response.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class RevenuesController : FinancialControlController
    {
        public RevenuesController(IMediator mediatR) : base(mediatR) { }

        /// <summary>
        /// Cadastra uma nova receita para o usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="201">A receita foi criada.</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpPost]
        public Task<RevenueCreateResponse> CreateRevenue([FromBody] RevenueCreateRequest request)
        {
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Busca uma receita específica no sistema
        /// </summary>
        /// <returns></returns>
        /// <response code="200">A receita foi encontrada.</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpGet("{id}")]
        public Task<RevenueGetResponse> Get([FromRoute] long id)
        {
            RevenueGetRequest request = new(id);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Busca uma receita específica no sistema
        /// </summary>
        /// <returns model="RevenueListResponse"></returns>
        /// <response code="200">Receitas coletadas com sucesso</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpGet()]
        public Task<RevenueListResponse> Get([FromQuery] RevenueListRequest request)
        {
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Atualiza uma receita específica no sistema
        /// </summary>
        /// <returns model="RevenueUpdateResponse"></returns>
        /// <response code="200">Receita ataulizada com sucesso</response>
        /// <response code="400">A receita não foi encontrada, pois o ID informado é inválido</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpPatch("{id}")]
        public Task<RevenueUpdateResponse> Update([FromRoute] long id, [FromBody] RevenueUpdateRequest request)
        {
            request.SetRequestId(id);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Remove uma receita específica no sistema
        /// </summary>
        /// <returns model="RevenueUpdateResponse"></returns>
        /// <response code="200">Receita deletada com sucesso</response>
        /// <response code="400">A receita não foi encontrada, pois o ID informado é inválido</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpDelete("{id}")]
        public Task<RevenueDeleteResponse> Delete([FromRoute] long id)
        {
            RevenueDeleteRequest request = new(id);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}