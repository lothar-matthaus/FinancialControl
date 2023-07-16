using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.List;

namespace Financial.Control.Application.Models.Cards.Response.List
{
    public sealed class CardListSuccessResponse : BaseSuccessResponse, ICardListSuccessResponse
    {
        public IReadOnlyCollection<ICardModel> Result { get; }
        private CardListSuccessResponse(IReadOnlyCollection<ICardModel> cards) => Result = cards;

        #region Factory
        public static CardListSuccessResponse Create(IReadOnlyCollection<ICardModel> cards) => new CardListSuccessResponse(cards);
        #endregion
    }
}
