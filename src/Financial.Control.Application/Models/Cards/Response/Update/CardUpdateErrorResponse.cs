using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Cards.Response.Update;

namespace Financial.Control.Application.Models.Cards.Response.Update
{
    public sealed class CardUpdateErrorResponse : BaseErrorResponse, ICardUpdateErrorResponse
    {
        private CardUpdateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors)
        {
        }

        public static CardUpdateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CardUpdateErrorResponse(message, errors);
    }
}
