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
using Financial.Control.Domain.ValueObjects;
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

            Card card = null;

            if (request.PaymentType != PaymentType.Money)
                card = await _unitOfWork.Cards.Query(card => card.Number.Equals(request.CardNumber))
                    .FirstOrDefaultAsync(cancellationToken);

            Payment payment = Payment.Create(request.Value, request.Installment, request.PaymentType);
            Expense expense = Expense.Create(request.Description, category, card, payment);

            if (!expense.IsValid())
            {
                _notificationManager.AddNotifications(expense.GetNotifications());
                return null;
            }

            user.AddExpense(expense);

            _unitOfWork.Users.Update(user);

            return ExpenseCreateResponse.AsSuccess(ExpenseMessage.ExpenseCreateSuccess(), HttpStatusCode.Created,
                SuccessResponse<IExpenseModel>.Create(ExpenseModel.Create(expense)));
        }
    }
}
