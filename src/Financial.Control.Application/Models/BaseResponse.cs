using Financial.Control.Domain.Models;
using System.Net;

namespace Financial.Control.Application.Models
{
    public abstract class BaseResponse<TSuccess, TError> :
        IBaseResponse<TSuccess, TError> where TSuccess : BaseSuccessResponse where TError : BaseErrorResponse
    {
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }
        public TSuccess Success { get; }
        public TError Error { get; set; }

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
