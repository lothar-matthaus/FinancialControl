using Financial.Control.Application.Models.Cards.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Models.Cards.Commands;
using MediatR;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public class CardCreateRequest : BaseRequest<CardCreateResponse>, ICardCreateRequest
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public CardFlag Flag { get; set; }
        public CardType CardType { get; set; }
        public decimal Limit { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public static implicit operator Card(CardCreateRequest request)
        {
            if (request.CardType.Equals(CardType.Credit))
                return CreditCard.Create(request.Name, request.Flag, request.Limit, request.CardNumber, request.PaymentDueDate);
            else
                return DebitCard.Create(request.Name, request.Flag, request.CardNumber);
        }
    }
}
