using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateErrorResponse : BaseErrorResponse
    {
        public UserCreateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }
    }
}
