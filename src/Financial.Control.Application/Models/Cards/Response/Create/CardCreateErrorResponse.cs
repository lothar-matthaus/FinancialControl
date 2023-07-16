
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Cards.Response.Create;

namespace Financial.Control.Application.Models.Cards.Response.Create
{
    public class CardCreateErrorResponse : BaseErrorResponse, ICardCreateErrorResponse
    {
        private CardCreateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        public static CardCreateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CardCreateErrorResponse(message, errors);
    }
}
