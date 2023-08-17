using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.List;
using System.Net;

namespace Financial.Control.Application.Models.Revenues.Response.List
{
    public sealed class RevenueListResponse : BaseResponse<ISuccessListResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IRevenueListResponse
    {
        public RevenueListResponse() { }
        private RevenueListResponse(string message, HttpStatusCode statusCode, ISuccessListResponse<IRevenueModel> success) : base(message, statusCode, success) { }
        private RevenueListResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueListResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessListResponse<IRevenueModel> success) => new RevenueListResponse(message, statusCode, success);
        public static RevenueListResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new RevenueListResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = message;
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
