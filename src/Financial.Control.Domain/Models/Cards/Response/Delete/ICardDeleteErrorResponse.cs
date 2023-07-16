using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Cards.Response.Delete
{
    public interface ICardDeleteErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
        
    }
}
