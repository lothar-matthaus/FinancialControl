using Financial.Control.Application.Models.Expenses.Commands;
using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Records;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Expenses
{
    public class ExpenseCreateHandler : BaseRequestHandler<ExpenseCreateRequest, ExpenseCreateResponse>
    {
        public ExpenseCreateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<ExpenseCreateResponse> Handle(ExpenseCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users.Query(user => user.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            Category category = await _app.UnitOfWork.Categories.Query(cat => cat.Id.Equals(request.CategoryId))
                .FirstOrDefaultAsync(cancellationToken);

            if (category is null)
                return ExpenseCreateResponse.AsError(ExpenseMessage.ExpenseCreateError(), HttpStatusCode.BadRequest, ExpenseCreateErrorResponse
                    .Create(CategoryMessage.CategoryGetNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(request.CategoryId) }) }));

            Card card = null;

            if (request.PaymentType != PaymentType.Money)
                card = await _app.UnitOfWork.Cards.Query(card => card.CardNumber.Equals(request.CardNumber))
                    .FirstOrDefaultAsync(cancellationToken);

            Expense expense = Expense.Create(request.Description, category, card, Payment.Create(request.Value, request.Instalment, request.PaymentType));

            user.AddExpense(expense);

            _app.UnitOfWork.Users.Update(user);

            return ExpenseCreateResponse.AsSuccess(ExpenseMessage.ExpenseCreateSuccess(), HttpStatusCode.Created, ExpenseCreateSuccessResponse.Create(expense));
        }
    }
}
