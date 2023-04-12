using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Cards.Response.Delete
{
    public interface ICardDeleteErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
