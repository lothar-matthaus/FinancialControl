
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Cards.Response.Update
{
    public interface ICardUpdateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
