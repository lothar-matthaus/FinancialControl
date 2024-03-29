﻿using Financial.Control.Domain.Entities;
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
        public int? CardInvoiceDay { get; }
        public KeyValuePair<CardType, string> Type { get; }
        public decimal? Limit { get; }

        public CardModel(Card card) : base(card.Id, card.CreationDate, card.UpdateDate)
        {
            CardNumber = card.Number;
            Name = card.Name;
            Flag = new KeyValuePair<CardFlag, string>(card.Flag, card.Flag.GetDescription());
            Type = new KeyValuePair<CardType, string>(card.Type, card.Type.GetDescription());
            CardInvoiceDay = (card as CreditCard)?.InvoiceDay;
            Limit = (card as CreditCard)?.Limit;
        }

        public static CardModel Create(Card card) => new CardModel(card);
    }
}
