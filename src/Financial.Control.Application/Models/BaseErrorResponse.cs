using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public abstract class BaseErrorResponse : IBaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; set; }

        protected BaseErrorResponse(IReadOnlyCollection<Notification> errors)
        {
            Errors = errors;
        }
    }
}
