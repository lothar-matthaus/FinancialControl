using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities
{
    public class CreditCard : Card
    {
        #region Properties
        public decimal Limit { get; private set; }
        public int CardInvoiceDay { get; private set; }
        #endregion

        protected CreditCard() : base() { }
        private CreditCard(string name, decimal limit, string number, int cardInvoiceDate) : base(name, CardType.Credit, number)
        {
            Limit = limit;
            CardInvoiceDay = cardInvoiceDate;
        }

        #region Behaviors
        public void SetCardInvoiceDate(int? cardInvoiceDate)
        {
            if (cardInvoiceDate is null)
                return;

            CardInvoiceDay = cardInvoiceDate.Value;
        }

        public void SetLimit(decimal? limit)
        {
            if (limit is null)
                return;

            Limit = limit.Value;
        }
        #endregion
        public static CreditCard Create(string name, decimal limit, string number, int CardInvoiceDay) => new CreditCard(name, limit, number, CardInvoiceDay);
    }
}
