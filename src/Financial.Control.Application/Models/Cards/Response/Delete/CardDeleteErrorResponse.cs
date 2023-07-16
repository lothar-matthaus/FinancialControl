using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Cards.Response.Delete;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteErrorResponse : BaseErrorResponse, ICardDeleteErrorResponse
    {
        private CardDeleteErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors)
        {
        }

        public static CardDeleteErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CardDeleteErrorResponse(message, errors);
    }
}
