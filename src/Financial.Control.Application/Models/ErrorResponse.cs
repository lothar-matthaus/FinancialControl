using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public class ErrorResponse : IErrorResponse
    {
        public string Message { get; }
        public IReadOnlyCollection<Notification> Errors { get; }

        private ErrorResponse(string message, IReadOnlyCollection<Notification> errors)
        {
            Message = message;
            Errors = errors;
        }

        #region Factory
        public static ErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new ErrorResponse(message, errors);
        #endregion
    }
}