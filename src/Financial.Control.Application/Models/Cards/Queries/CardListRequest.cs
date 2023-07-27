using Financial.Control.Application.Models.Cards.Response.List;
using Financial.Control.Domain.Models.Cards.Queries;
namespace Financial.Control.Application.Models.Cards.Queries
{
    public sealed class CardListRequest : BaseRequest<CardListResponse>, ICardListRequest
    {
        public CardListRequest() { }
    }
}
