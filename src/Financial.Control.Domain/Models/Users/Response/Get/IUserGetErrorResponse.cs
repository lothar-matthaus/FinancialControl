using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Users.Response.Get
{
    public interface IUserGetErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }

    }
}
