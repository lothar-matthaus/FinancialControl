
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Revenues.Response.Create
{
    public interface IRevenueCreateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
