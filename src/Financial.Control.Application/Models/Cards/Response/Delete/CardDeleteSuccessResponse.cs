using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Delete;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteSuccessResponse : BaseSuccessResponse, ICardDeleteSuccessResponse
    {
        public ICardModel Result { get; }
        private CardDeleteSuccessResponse(Card card) => Result = CardModel.Create(card);
        public static CardDeleteSuccessResponse Create(Card card) => new CardDeleteSuccessResponse(card);
    }
}
