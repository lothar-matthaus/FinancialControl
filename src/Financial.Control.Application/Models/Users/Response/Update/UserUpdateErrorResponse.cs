using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateErrorResponse : IBaseErrorResponse
    {
        public IReadOnlyCollection<Notification> Errors { get; }

        public UserUpdateErrorResponse(IReadOnlyCollection<Notification> errors) => Errors = errors;
        public static UserUpdateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new UserUpdateErrorResponse(errors);
    }

}
