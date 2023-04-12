using Financial.Control.Domain.Entities.NotificationEntity;

namespace Financial.Control.Domain.Models.Cards.Response.Update
{
    public interface ICardUpdateErrorResponse : IBaseErrorResponse
    {
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
