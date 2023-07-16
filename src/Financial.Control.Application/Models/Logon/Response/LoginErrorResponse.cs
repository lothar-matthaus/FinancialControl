using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Logon.Response;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginErrorResponse : BaseErrorResponse, ILoginErrorResponse
    {
        private LoginErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        public static ILoginErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new LoginErrorResponse(message, errors);
    }
}
