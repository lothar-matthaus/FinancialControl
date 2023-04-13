using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Cards.Response.List
{
    public interface ICardListErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }

    }
}
