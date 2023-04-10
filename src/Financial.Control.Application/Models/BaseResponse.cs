using Financial.Control.Domain.Models;
using System.Net;

namespace Financial.Control.Application.Models
{
    public abstract class BaseResponse<TSuccess, TError> : IBaseResponse<TSuccess, TError> where TSuccess : IBaseSuccessResponse where TError : IBaseErrorResponse
    {
        public string Message { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
        public TSuccess Success { get; protected set; }
        public TError Error { get; protected set; }

        protected BaseResponse()
        {

        }
        protected BaseResponse(string message, HttpStatusCode statusCode, TSuccess success)
        {
            Message = message;
            StatusCode = statusCode;
            Success = success;
        }
        protected BaseResponse(string message, HttpStatusCode statusCode, TError error)
        {
            Message = message;
            StatusCode = statusCode;
            Error = error;
        }
    }
}
