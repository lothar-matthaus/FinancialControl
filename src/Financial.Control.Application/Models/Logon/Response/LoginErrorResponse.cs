using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Logon.Response;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginErrorResponse : BaseErrorResponse, ILoginErrorResponse
    {
        private LoginErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }

        public static ILoginErrorResponse Create(IReadOnlyCollection<Notification> errors) => new LoginErrorResponse(errors);
    }
}
