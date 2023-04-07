using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateErrorResponse : BaseErrorResponse
    {
        private UserCreateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }
        public static UserCreateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserCreateErrorResponse(errors);
    }
}
