using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Categories.Queries;
using Financial.Control.Application.Models.Categories.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers
{
    [Authorize]
    public class CategoriesController : FinancialControlController
    {
        public CategoriesController(IMediator mediatR) : base(mediatR) { }

        /// <summary>
        /// Lista as categorias de acordo com os filtros informados
        /// </summary>
        /// <response code="200">Foram encontradas categorias ou não cadastradas no sistema.</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpGet]
        public async Task<CategoryListResponse> Post([FromQuery] CategoryListRequest request)
        {
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
