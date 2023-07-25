using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Revenues.Response.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Revenues.Response.Update
{
    public class RevenueUpdateResponse : BaseResponse<IRevenueUpdateSuccessResponse, IRevenueUpdateErrorResponse>, IRevenueUpdateResponse
    {
        public RevenueUpdateResponse() { }
        private RevenueUpdateResponse(string message, HttpStatusCode statusCode, IRevenueUpdateSuccessResponse success) : base(message, statusCode, success) { }
        private RevenueUpdateResponse(string message, HttpStatusCode statusCode, IRevenueUpdateErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueUpdateResponse AsError(string message, HttpStatusCode statusCode, IRevenueUpdateErrorResponse error) => new RevenueUpdateResponse(message, statusCode, error);
        public static RevenueUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, IRevenueUpdateSuccessResponse success) => new RevenueUpdateResponse(message, statusCode, success);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = RevenueMessage.RevenueUpdateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = RevenueUpdateErrorResponse.Create(message, errors);
        }
    }
}
