using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Revenues.Response.Create
{
    public interface IRevenueCreateErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }

    }
}
