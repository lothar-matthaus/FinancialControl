using Financial.Control.Domain.Entities.NotificationEntity;
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
        public abstract void SetInvalidState(IReadOnlyCollection<Notification> errors);
    }
}
