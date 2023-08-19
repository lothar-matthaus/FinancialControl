using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Expenses;
using Financial.Control.Application.Models.Expenses.Queries;
using Financial.Control.Application.Models.Expenses.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Expenses
{
    internal class ExpenseGetHandler : BaseRequestHandler<ExpenseGetRequest, ExpenseGetResponse>
    {
        public ExpenseGetHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }
        public async override Task<ExpenseGetResponse> Handle(ExpenseGetRequest request, CancellationToken cancellationToken)
        {
            Expense expense = await _unitOfWork.Expenses
                .Query(ex => ex.Id.Equals(request.Id) && 
                      (ex.User.Id.Equals(_applicationUser.Id)))
                .Include(ex => ex.Category)
                .FirstOrDefaultAsync(cancellationToken);

            if (expense is null)
            {
                return ExpenseGetResponse.AsError(message: ExpenseMessage.ExpenseGetError(), statusCode: HttpStatusCode.BadRequest,
                    error: ErrorResponse.Create(message: ExpenseMessage.ExpenseGetNotFound(), error: Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id))));
            }

            return ExpenseGetResponse.AsSuccess(message: ExpenseMessage.ExpenseGetSuccess(), statusCode: HttpStatusCode.OK,
                success: SuccessSingleResponse<IExpenseModel>.Create(ExpenseModel.Create(expense)));
        }
    }
}
