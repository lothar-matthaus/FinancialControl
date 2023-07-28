using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Revenues.Response.List
{
    public interface IRevenueListErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
