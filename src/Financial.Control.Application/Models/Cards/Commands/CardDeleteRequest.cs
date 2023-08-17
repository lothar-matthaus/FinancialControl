using Financial.Control.Application.Models.Cards.Response.Delete;
using Financial.Control.Domain.Models.Cards.Commands;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public sealed class CardDeleteRequest : BaseRequest<CardDeleteResponse>, ICardDeleteRequest
    {
        public long Id { get; }
        public CardDeleteRequest(long id)
        {
            Id = id;
        }
    }
}
