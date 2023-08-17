using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Expenses;
using Financial.Control.Application.Models.Expenses.Queries;
using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Expenses
{
    public class ExpenseListHandler : BaseRequestHandler<ExpenseListRequest, ExpenseListResponse>
    {
        public ExpenseListHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<ExpenseListResponse> Handle(ExpenseListRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Expense> expenses = await _unitOfWork.Expenses.Query(ex => ex.User.Id.Equals(_applicationUser.Id)).ToListAsync(cancellationToken);
            IReadOnlyCollection<IExpenseModel> expenseModels = expenses.Select(ex => ExpenseModel.Create(ex)).ToImmutableList();

            return ExpenseListResponse.AsSuccess(message: expenseModels.Any() ? ExpenseMessage.ExpenseListSuccess() : ExpenseMessage.ExpenseListNotFound(), statusCode: HttpStatusCode.OK, 
                success: SuccessListResponse<IExpenseModel>.Create(expenseModels));
        }
    }
}
