using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models
{
    public interface IBaseErrorResponse
    {
        public abstract IReadOnlyCollection<Notification> Errors { get; }
    }
}
