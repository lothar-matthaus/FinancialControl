using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Get;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Get
{
    public sealed class RevenueGetResponse : BaseResponse<IRevenueGetSuccessResponse, IRevenueGetErrorResponse>, IRevenueGetResponse
    {
        public RevenueGetResponse() { }
        private RevenueGetResponse(string message, HttpStatusCode statusCode, IRevenueGetSuccessResponse success) : base(message, statusCode, success) { }
        private RevenueGetResponse(string message, HttpStatusCode statusCode, IRevenueGetErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueGetResponse AsSuccess(string message, HttpStatusCode statusCode, IRevenueGetSuccessResponse success) => new RevenueGetResponse(message, statusCode, success);
        public static RevenueGetResponse AsError(string message, HttpStatusCode statusCode, IRevenueGetErrorResponse error) => new RevenueGetResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = RevenueGetErrorResponse.Create(message, errors);
        }
    }
}
