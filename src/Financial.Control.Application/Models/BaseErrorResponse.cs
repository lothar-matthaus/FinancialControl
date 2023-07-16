
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public abstract class BaseErrorResponse : IBaseErrorResponse
    {
        public string Message { get; }
        public IReadOnlyCollection<Notification> Errors { get; }

        protected BaseErrorResponse(string message, IReadOnlyCollection<Notification> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}