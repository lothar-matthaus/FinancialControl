﻿using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Create;
using System.Net;

namespace Financial.Control.Application.Models.Revenues.Response.Create
{
    public class RevenueCreateResponse : BaseResponse<IRevenueCreateSuccessResponse, IRevenueCreateErrorResponse>, IRevenueCreateResponse
    {
        public RevenueCreateResponse() { }
        private RevenueCreateResponse(string message, HttpStatusCode statusCode, IRevenueCreateSuccessResponse success) : base(message, statusCode, success) { }
        private RevenueCreateResponse(string message, HttpStatusCode statusCode, IRevenueCreateErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static RevenueCreateResponse AsSuccess(string message, HttpStatusCode statusCode, IRevenueCreateSuccessResponse success) => new RevenueCreateResponse(message, statusCode, success);
        public static RevenueCreateResponse AsError(string message, HttpStatusCode statusCode, IRevenueCreateErrorResponse error) => new RevenueCreateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = message;
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = RevenueCreateErrorResponse.Create(message, errors);
        }
    }
}
