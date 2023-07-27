using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues.Response.Create;
using Financial.Control.Domain.Models.Revenues.Response.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Delete
{
    public class RevenueDeleteResponse : BaseResponse<IRevenueDeleteSuccessResponse, IRevenueDeleteErrorResponse>, IRevenueDeleteResponse
    {
        public RevenueDeleteResponse()
        {
        }

        private RevenueDeleteResponse(string message, HttpStatusCode statusCode, IRevenueDeleteSuccessResponse success) : base(message, statusCode, success)
        {
        }

        private RevenueDeleteResponse(string message, HttpStatusCode statusCode, IRevenueDeleteErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static RevenueDeleteResponse AsSuccess(string message, HttpStatusCode statusCode, IRevenueDeleteSuccessResponse success) => new RevenueDeleteResponse(message, statusCode, success);
        public static RevenueDeleteResponse AsError(string message, HttpStatusCode statusCode, IRevenueDeleteErrorResponse error) => new RevenueDeleteResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueDeleteError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = RevenueDeleteErrorResponse.Create(message, errors);
        }
    }
}
