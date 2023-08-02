using Financial.Control.Application.Controllers.Base;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Application.Models.Expenses.Commands;
using Financial.Control.Application.Models.Expenses.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Controllers
{
    public class ExpensesController : FinancialControlController
    {
        public ExpensesController(IMediator mediatR) : base(mediatR) { }

        /// <summary>
        /// Cria uma nova despesa.
        /// </summary>
        /// <response code="201">A despesa foi criado com sucesso.</response>
        /// <response code="500">Erro interno ocorrido no servidor</response>
        [HttpPost]
        public async Task<ExpenseCreateResponse> Post([FromBody] ExpenseCreateRequest request)
        {
            request.SetModelState(ModelState);
            return await _mediatR.Send(request, HttpContext.RequestAborted);
        }
    }
}
