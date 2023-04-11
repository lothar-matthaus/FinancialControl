using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Models.Cards.Commands
{
    public interface ICardCreateRequest : IBaseRequest
    {
        public string Name { get; }
        public string CardNumber { get; }
        public CardFlag Flag { get; }
        public CardType CardType { get; }
        public decimal Limit { get; }
        public DateTime PaymentDueDate { get; }
    }
}
