using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Expenses;
using Financial.Control.Application.Models.Expenses.Commands;
using Financial.Control.Application.Models.Expenses.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Expenses
{
    public class ExpenseCreateHandler : BaseRequestHandler<ExpenseCreateRequest, ExpenseCreateResponse>
    {
        public ExpenseCreateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<ExpenseCreateResponse> Handle(ExpenseCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users.Query(user => user.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            Category category = await _unitOfWork.Categories.Query(cat => cat.Id.Equals(request.CategoryId))
                .FirstOrDefaultAsync(cancellationToken);

            if (category is null)
                return ExpenseCreateResponse.AsError(ExpenseMessage.ExpenseCreateError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(CategoryMessage.CategoryGetNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.CategoryId)) }));

            Card card = null;

            if (request.PaymentType != PaymentType.Money)
                card = await _unitOfWork.Cards.Query(card => card.Number.Equals(request.CardNumber))
                    .FirstOrDefaultAsync(cancellationToken);

            Expense expense = Expense.Create(request.Description, category, card, request.Value, request.Installment, request.PaymentType);

            if (!expense.IsValid())
                _notificationManager.AddNotifications(expense.GetNotifications());

            user.AddExpense(expense);

            _unitOfWork.Users.Update(user);

            return ExpenseCreateResponse.AsSuccess(ExpenseMessage.ExpenseCreateSuccess(), HttpStatusCode.Created,
                SuccessSingleResponse<IExpenseModel>.Create(ExpenseModel.Create(expense)));
        }
    }
}
