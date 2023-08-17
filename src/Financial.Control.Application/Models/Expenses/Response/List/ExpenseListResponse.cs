using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Models.Expenses.Response;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Expenses.Response.List
{
    public class ExpenseListResponse : BaseResponse<ISuccessListResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IExpenseListResponse
    {
        public ExpenseListResponse() { }
        private ExpenseListResponse(string message, HttpStatusCode statusCode, ISuccessListResponse<IExpenseModel> success) : base(message, statusCode, success) { }
        private ExpenseListResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }


        #region Factory
        public static ExpenseListResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessListResponse<IExpenseModel> success) => new ExpenseListResponse(message, statusCode, success);
        public static ExpenseListResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new ExpenseListResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = ExpenseMessage.ExpenseListError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
