using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Users.Response.Get;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetErrorResponse : BaseErrorResponse, IUserGetErrorResponse
    {
        private UserGetErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
            Errors = errors;
        }

        public static UserGetErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserGetErrorResponse(errors);
    }
}
