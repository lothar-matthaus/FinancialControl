using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Users.Response.Get;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetErrorResponse : BaseErrorResponse, IUserGetErrorResponse
    {
        private UserGetErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        public static UserGetErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new UserGetErrorResponse(message, errors);
    }
}
