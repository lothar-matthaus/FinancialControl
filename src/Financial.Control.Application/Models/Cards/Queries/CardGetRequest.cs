using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Domain.Models.Cards.Queries;

namespace Financial.Control.Application.Models.Cards.Queries
{
    public class CardGetRequest : BaseRequest<CardGetResponse>, ICardGetRequest
    {
        public long CardId { get; }
        private CardGetRequest(long id) => CardId = id;

        #region Factory
        public static CardGetRequest Create(long id) => new CardGetRequest(id);
        #endregion
    }
}
