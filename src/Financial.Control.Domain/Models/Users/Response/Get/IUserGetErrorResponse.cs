
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Users.Response.Get
{
    public interface IUserGetErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
