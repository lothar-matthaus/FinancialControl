using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Cards.Response.List;

namespace Financial.Control.Application.Models.Cards.Response.List
{
    public sealed class CardListErrorResponse : BaseErrorResponse, ICardListErrorResponse
    {
        public CardListErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Create
        public static CardListErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CardListErrorResponse(message, errors);
        #endregion
    }
}
