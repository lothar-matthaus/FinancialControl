using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Cards.Response.Get
{
    public interface ICardGetErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
