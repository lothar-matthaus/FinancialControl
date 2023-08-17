using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Delete;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Delete
{
    public class RevenueDeleteResponse : BaseResponse<ISuccessSingleResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IRevenueDeleteResponse
    {
        public RevenueDeleteResponse()
        {
        }

        private RevenueDeleteResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) : base(message, statusCode, success)
        {
        }

        private RevenueDeleteResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static RevenueDeleteResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) => new RevenueDeleteResponse(message, statusCode, success);
        public static RevenueDeleteResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new RevenueDeleteResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueDeleteError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
