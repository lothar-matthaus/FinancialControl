using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Expenses;
using Financial.Control.Application.Models.Expenses.Commands;
using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Expenses
{
    internal class ExpenseUpdateHandler : BaseRequestHandler<ExpenseUpdateRequest, ExpenseUpdateResponse>
    {
        public ExpenseUpdateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }

        public async override Task<ExpenseUpdateResponse> Handle(ExpenseUpdateRequest request, CancellationToken cancellationToken)
        {
            Expense expense = await _unitOfWork.Expenses.Query(ex => ex.Id.Equals(request.Id)).FirstOrDefaultAsync(cancellationToken);
            Category category = await _unitOfWork.Categories.Query(cat => cat.Id.Equals(request.CategoryId)).FirstOrDefaultAsync(cancellationToken);

            if (expense is null)
            {
                return ExpenseUpdateResponse.AsError(message: ExpenseMessage.ExpenseUpdateError(), statusCode: HttpStatusCode.BadRequest, error: ErrorResponse.Create(
                        message: ExpenseMessage.ExpenseGetError(), error: Notification.Create(
                            context: request.GetType().Name, field: "Id", message: ExpenseMessage.ExpenseGetNotFound())));
            }

            expense.SetDescription(request.Description);
            expense.SetCategory(category);

            if (!expense.IsValid())
            {
                _notificationManager.AddNotifications(expense.GetNotifications());
                return null;
            }

            _unitOfWork.Expenses.Update(expense);

            return ExpenseUpdateResponse.AsSuccess(message: ExpenseMessage.ExpenseUpdateSuccess(), statusCode: HttpStatusCode.OK, 
                success: SuccessSingleResponse<IExpenseModel>.Create(ExpenseModel.Create(expense)));
        }
    }
}
