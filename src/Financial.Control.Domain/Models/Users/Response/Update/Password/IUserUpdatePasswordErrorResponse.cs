using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Users.Response.Update.Password
{
    public interface IUserUpdatePasswordErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
