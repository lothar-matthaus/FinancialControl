using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models
{
    public interface IBaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; }
    }
}
