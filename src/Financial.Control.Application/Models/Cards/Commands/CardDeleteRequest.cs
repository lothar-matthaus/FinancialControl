using Financial.Control.Application.Models.Cards.Response.Delete;
using Financial.Control.Domain.Models.Cards.Commands;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public sealed class CardDeleteRequest : BaseRequest<CardDeleteResponse>, ICardDeleteRequest
    {
        public long CardId { get; private set; }
        private CardDeleteRequest(long cardId)
        {
            CardId = cardId;
        }
        
        public static CardDeleteRequest Create(long id) => new CardDeleteRequest(id);
    }
}
