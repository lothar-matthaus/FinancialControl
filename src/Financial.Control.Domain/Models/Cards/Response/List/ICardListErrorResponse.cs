
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Cards.Response.List
{
    public interface ICardListErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
        
    }
}
