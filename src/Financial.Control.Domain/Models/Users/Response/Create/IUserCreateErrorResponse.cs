
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Users.Response.Create
{
    public interface IUserCreateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
        
    }
}
