﻿
using Financial.Control.Domain.Entities.Notifications;
using System.Net;

namespace Financial.Control.Domain.Models
{
    public interface IBaseResponse<TSuccess, TError>
        where TSuccess : IBaseSuccessResponse
        where TError : IBaseErrorResponse
    {
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }
        public TSuccess Success { get; }
        public TError Error { get; }
    }
    public interface IBaseResponse
    {
        public HttpStatusCode StatusCode { get; }
        public abstract void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null);
    }
}
