using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Logon.Response
{
    public interface ILoginErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
