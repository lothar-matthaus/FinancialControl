using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Create;
using System.Net;

namespace Financial.Control.Application.Models.Revenues.Response.Create
{
    public class RevenueCreateResponse : BaseResponse<ISuccessSingleResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IRevenueCreateResponse
    {
        public RevenueCreateResponse() { }
        private RevenueCreateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) : base(message, statusCode, success) { }
        private RevenueCreateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueCreateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IRevenueModel> success) => new RevenueCreateResponse(message, statusCode, success);
        public static RevenueCreateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new RevenueCreateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = message;
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
