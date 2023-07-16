
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Cards.Response.Get
{
    public interface ICardGetErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
