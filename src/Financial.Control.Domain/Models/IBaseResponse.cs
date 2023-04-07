using System.Net;

namespace Financial.Control.Domain.Models
{
    public interface IBaseResponse<TSuccess, TError>
        where TSuccess : class
        where TError : class
    {
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }
        public TSuccess Success { get; }
        public TError Error { get; set; }
    }
}
