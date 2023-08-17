using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Models.Expenses.Response;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Expenses.Response
{
    public sealed class ExpenseGetResponse : BaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IExpenseGetResponse
    {
        public ExpenseGetResponse()
        {
        }
        private ExpenseGetResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) : base(message, statusCode, success) { }
        private ExpenseGetResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static ExpenseGetResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IExpenseModel> success) => new ExpenseGetResponse(message, statusCode, success);
        public static ExpenseGetResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new ExpenseGetResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = ExpenseMessage.ExpenseGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
