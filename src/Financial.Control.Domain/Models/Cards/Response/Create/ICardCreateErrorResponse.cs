using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Cards.Response.Create
{
    public interface ICardCreateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
