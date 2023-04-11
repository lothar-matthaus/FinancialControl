using Financial.Control.Application.Models.Cards.Response;
using Financial.Control.Application.Validation.Cards;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Models.Cards.Commands;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Cards.Commands
{
    public class CardCreateRequest : BaseRequest<CardCreateResponse>, ICardCreateRequest
    {
        [Required]
        [NameValidation(isRequired: true)]
        public string Name { get; set; }

        [Required]
        [CardNumberValidation]
        public string CardNumber { get; set; }

        [Required]
        public CardType CardType { get; set; }

        public decimal Limit { get; set; }

        public DateTime PaymentDueDate { get; set; }

        public static implicit operator Card(CardCreateRequest request)
        {
            if (request.CardType.Equals(CardType.Credit))
                return CreditCard.Create(request.Name, request.Limit, request.CardNumber, request.PaymentDueDate);
            else
                return DebitCard.Create(request.Name, request.CardNumber);
        }
    }
}
