using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Users.Response.Update
{
    public interface IUserUpdateErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
