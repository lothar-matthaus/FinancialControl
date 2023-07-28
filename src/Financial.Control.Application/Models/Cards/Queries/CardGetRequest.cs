using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Domain.Models.Cards.Queries;

namespace Financial.Control.Application.Models.Cards.Queries
{
    public class CardGetRequest : BaseRequest<CardGetResponse>, ICardGetRequest
    {
        public long Id { get; }
        private CardGetRequest(long id) => Id = id;


        #region Factory
        public static CardGetRequest Create(long id) => new CardGetRequest(id);

        public void SetRequestId(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
