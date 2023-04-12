using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Update;

namespace Financial.Control.Application.Models.Cards.Response.Update
{
    public sealed class CardUpdateSuccessResponse : BaseSuccessResponse, ICardUpdateSuccessResponse
    {
        public ICardModel Result { get; }

        private CardUpdateSuccessResponse(Card card)
        {
            Result = CardModel.Create(card);
        }

        public static CardUpdateSuccessResponse Create(Card card) => new CardUpdateSuccessResponse(card);
    }
}
