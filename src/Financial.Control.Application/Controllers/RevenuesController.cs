using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Queries.Get;
using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Application.Models.Revenues.Response.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenuesController : BaseController
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
        [Authorize]
        public Task<RevenueCreateResponse> CreateRevenue([FromBody] RevenueCreateRequest request)
        {
            request.SetModelState(ModelState);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }

        /// <summary>
        /// Busca uma receita específica no sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">A receita foi encontrada.</response>
        /// <response code="500">Erro interno do sistema.</response>
        [HttpGet]
        [Authorize]
        public Task<RevenueGetResponse> GetRevenue([FromQuery] RevenueGetRequest request)
        {
            request.SetModelState(ModelState);
            return _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
