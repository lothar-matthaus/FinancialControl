using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Models.Expenses.Response;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Expenses.Response
{
    public class ExpenseCreateResponse : BaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IExpenseCreateResponse
    {
        public ExpenseCreateResponse()
        {
        }

        private ExpenseCreateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) : base(message, statusCode, success) { }
        private ExpenseCreateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static ExpenseCreateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) => new ExpenseCreateResponse(message, statusCode, success);
        public static ExpenseCreateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new ExpenseCreateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = ExpenseMessage.ExpenseCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
