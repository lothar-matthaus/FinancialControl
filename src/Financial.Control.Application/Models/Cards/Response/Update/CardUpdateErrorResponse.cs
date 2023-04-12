using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Update;

namespace Financial.Control.Application.Models.Cards.Response.Update
{
    public sealed class CardUpdateErrorResponse : BaseErrorResponse, ICardUpdateErrorResponse
    {
        private CardUpdateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }

        public static CardUpdateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardUpdateErrorResponse(errors);
    }
}
