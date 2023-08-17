using Financial.Control.Application.Models.Cards.Response.Update;
using Financial.Control.Domain.Models.Cards.Commands;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public sealed class CardUpdateRequest : BaseRequest<CardUpdateResponse>, ICardUpdateRequest
    {
        public long Id { get; private set; }
        public string CardName { get; set; }
        public decimal? Limit { get; set; }
        public int? CardInvoiceDay { get; set; }

        public void SetRequestId(long id)
        {
            Id = id;
        }
    }
}
