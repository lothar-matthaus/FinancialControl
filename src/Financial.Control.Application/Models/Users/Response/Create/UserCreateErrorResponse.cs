using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Users.Response.Create;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateErrorResponse : BaseErrorResponse, IUserCreateErrorResponse
    {
        private UserCreateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }
        public static IUserCreateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserCreateErrorResponse(errors);
    }
}
