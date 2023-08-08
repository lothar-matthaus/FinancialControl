using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Models.Cards.Commands;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public class CardCreateRequest : BaseRequest<CardCreateResponse>, ICardCreateRequest
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public decimal? Limit { get; set; }
        public int? CardInvoiceDay { get; set; }

        public static implicit operator Card(CardCreateRequest request)
        {
            if (request.CardType.Equals(CardType.Credit))
                return CreditCard.Create(request.Name, request.Limit.Value, request.CardNumber, request.CardInvoiceDay.Value);
            else
                return DebitCard.Create(request.Name, request.CardNumber);
        }
    }
}
