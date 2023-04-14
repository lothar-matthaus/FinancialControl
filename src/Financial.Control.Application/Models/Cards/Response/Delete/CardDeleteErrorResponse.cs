using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Delete;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteErrorResponse : BaseErrorResponse, ICardDeleteErrorResponse
    {
        private CardDeleteErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }

        public static CardDeleteErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardDeleteErrorResponse(errors);
    }
}
