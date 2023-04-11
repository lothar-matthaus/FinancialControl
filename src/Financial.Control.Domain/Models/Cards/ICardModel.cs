using Financial.Control.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Cards
{
    public interface ICardModel
    {
        public string CardNumber { get; }
        public string Name { get; }
        public KeyValuePair<CardFlag, string> Flag { get; }
        public DateTime? PaymentDueDate { get; }
        public KeyValuePair<CardType, string> Type { get; }
        public decimal? Limit { get; }
    }
}
