using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Logon.Response
{
    public interface ILoginErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
