using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Get;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Get
{
    public sealed class RevenueGetResponse : BaseResponse<ISuccessResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IRevenueGetResponse
    {
        public RevenueGetResponse() { }
        private RevenueGetResponse(string message, HttpStatusCode statusCode, ISuccessResponse<IRevenueModel> success) : base(message, statusCode, success) { }
        private RevenueGetResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueGetResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessResponse<IRevenueModel> success) => new RevenueGetResponse(message, statusCode, success);
        public static RevenueGetResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new RevenueGetResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
