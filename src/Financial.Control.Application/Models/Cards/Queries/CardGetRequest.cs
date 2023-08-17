using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Domain.Models.Cards.Queries;

namespace Financial.Control.Application.Models.Cards.Queries
{
    public class CardGetRequest : BaseRequest<CardGetResponse>, ICardGetRequest
    {
        public long Id { get; }
        public CardGetRequest(long id) => Id = id;
    }
}
