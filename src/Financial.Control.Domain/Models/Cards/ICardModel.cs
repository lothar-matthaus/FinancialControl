using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Models.Cards
{
    public interface ICardModel : IBaseModel
    {
        public new long Id { get; }
        public string CardNumber { get; }
        public string Name { get; }
        public KeyValuePair<CardFlag, string> Flag { get; }
        public int? CardInvoiceDay { get; }
        public KeyValuePair<CardType, string> Type { get; }
        public decimal? Limit { get; }
    }
}
