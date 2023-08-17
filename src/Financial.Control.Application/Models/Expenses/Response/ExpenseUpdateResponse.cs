using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Models.Expenses.Response;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Expenses.Response
{
    public sealed class ExpenseUpdateResponse : BaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IExpenseUpdateResponse
    {
        public ExpenseUpdateResponse()
        {
        }
        private ExpenseUpdateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) : base(message, statusCode, success)
        {
        }

        private ExpenseUpdateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static ExpenseUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) => new ExpenseUpdateResponse(message, statusCode, success);
        public static ExpenseUpdateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new ExpenseUpdateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = ExpenseMessage.ExpenseUpdateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
