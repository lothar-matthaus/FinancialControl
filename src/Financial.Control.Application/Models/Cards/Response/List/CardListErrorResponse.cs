using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.List;

namespace Financial.Control.Application.Models.Cards.Response.List
{
    public sealed class CardListErrorResponse : BaseErrorResponse, ICardListErrorResponse
    {
        public CardListErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }

        #region Create
        public static CardListErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardListErrorResponse(errors);
        #endregion
    }
}
