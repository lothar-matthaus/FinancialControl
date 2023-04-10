using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginErrorResponse : BaseErrorResponse
    {
        private LoginErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }

        public static LoginErrorResponse Create(IReadOnlyCollection<Notification> errors) => new LoginErrorResponse(errors);
    }
}
