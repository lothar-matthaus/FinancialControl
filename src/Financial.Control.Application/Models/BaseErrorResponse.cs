using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Application.Models
{
    public abstract class BaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; }
        public BaseErrorResponse(IReadOnlyCollection<Notification> errors)
        {
            Errors = errors;
        }
    }
}
