using Financial.Control.Domain.Entities.NotificationEntity;
using System.Runtime.CompilerServices;

namespace Financial.Control.Domain.Models.Users.Response.Create
{
    public interface IUserCreateErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
