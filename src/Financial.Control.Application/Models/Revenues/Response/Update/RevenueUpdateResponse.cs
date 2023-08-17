using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Update;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Update
{
    public class RevenueUpdateResponse : BaseResponse<ISuccessSingleResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IRevenueUpdateResponse
    {
        public RevenueUpdateResponse() { }
        private RevenueUpdateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) : base(message, statusCode, success) { }
        private RevenueUpdateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueUpdateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new RevenueUpdateResponse(message, statusCode, error);
        public static RevenueUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) => new RevenueUpdateResponse(message, statusCode, success);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueUpdateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
