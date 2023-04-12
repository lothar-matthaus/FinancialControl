using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Create;

namespace Financial.Control.Application.Models.Cards.Response.Create
{
    public sealed class CardCreateSuccessResponse : BaseSuccessResponse, ICardCreateSuccessResponse
    {
        public ICardModel Result { get; }
        private CardCreateSuccessResponse(Card card)
        {
            Result = CardModel.Create(card);
        }

        public static CardCreateSuccessResponse Create(Card card) => new CardCreateSuccessResponse(card);
    }
}
