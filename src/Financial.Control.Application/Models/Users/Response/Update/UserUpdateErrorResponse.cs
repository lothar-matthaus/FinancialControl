using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Users.Response.Update;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateErrorResponse : BaseErrorResponse, IUserUpdateErrorResponse
    {
        private UserUpdateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }
        public static UserUpdateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserUpdateErrorResponse(errors);
    }

}
