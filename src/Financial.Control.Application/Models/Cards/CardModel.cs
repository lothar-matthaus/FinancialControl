using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Extensions;
using Financial.Control.Domain.Models.Cards;

namespace Financial.Control.Application.Models.Cards
{
    public class CardModel : BaseModel, ICardModel
    {
        public string CardNumber { get; }
        public string Name { get; }
        public KeyValuePair<CardFlag, string> Flag { get; }
        public DateTime? PaymentDueDate { get; }
        public KeyValuePair<CardType, string> Type { get; }
        public decimal? Limit { get; }

        public CardModel(Card card) : base(card.Id)
        {
            CardNumber = card.CardNumber;
            Name = card.Name;
            Flag = new KeyValuePair<CardFlag, string>(card.Flag, card.Flag.GetDescription());
            Type = new KeyValuePair<CardType, string>(card.CardType, card.CardType.GetDescription());
            PaymentDueDate = (card as CreditCard)?.PaymentDueDate;
            Limit = (card as CreditCard)?.Limit;
        }

        public static CardModel Create(Card card) => new CardModel(card);
    }
}
