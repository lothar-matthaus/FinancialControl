using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Revenues.Response.Get
{
    public interface IRevenueGetErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
