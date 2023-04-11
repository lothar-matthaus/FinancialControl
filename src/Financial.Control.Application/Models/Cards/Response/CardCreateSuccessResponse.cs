using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response;

namespace Financial.Control.Application.Models.Cards.Response
{
    public class CardCreateSuccessResponse : BaseSuccessResponse, ICardCreateSuccessResponse
    {
        public ICardModel Result { get; }
        private CardCreateSuccessResponse(Card card)
        {
            Result = CardModel.Create(card);
        }

        public static CardCreateSuccessResponse Create(Card card) => new CardCreateSuccessResponse(card);
    }
}
