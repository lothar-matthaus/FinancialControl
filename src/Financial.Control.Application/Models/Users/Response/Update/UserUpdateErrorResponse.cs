using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Users.Response.Update;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateErrorResponse : BaseErrorResponse, IUserUpdateErrorResponse
    {
        private UserUpdateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message,errors) { }
        public static UserUpdateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new UserUpdateErrorResponse(message, errors);
    }

}
