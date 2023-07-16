using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Users.Response.Create;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateErrorResponse : BaseErrorResponse, IUserCreateErrorResponse
    {
        private UserCreateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors)
        {
        }
        public static IUserCreateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new UserCreateErrorResponse(message, errors);
    }
}
