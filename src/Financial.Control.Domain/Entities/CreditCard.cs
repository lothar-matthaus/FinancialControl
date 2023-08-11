using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities
{
    public class CreditCard : Card
    {
        #region Private properties
        private decimal _limit;
        private int _invoiceDay;
        #endregion

        #region Properties
        public int InvoiceDay
        {
            get { return _invoiceDay; }
            set
            {
                Validate(isInvalidIf: (value == default),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(InvoiceDay), "A data de vencimento da fatura deve ser informada."),
                         ifValid: () => _invoiceDay = value);

                Validate(isInvalidIf: (value > 31),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(InvoiceDay), "A data de vencimento não é válida."),
                         ifValid: () => _invoiceDay = value);
            }
        }

        public decimal Limit
        {
            get { return _limit; }
            set
            {
                Validate(isInvalidIf: (value == default),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Limit), "O limite informado não é válido."),
                         ifValid: () => _limit = value);
            }
        }
        #endregion

        protected CreditCard() : base() { }
        private CreditCard(string name, decimal limit, string number, int invoiceDate) : base(name, CardType.Credit, number)
        {
            Limit = limit;
            InvoiceDay = invoiceDate;
        }

        #region Behaviors
        public void SetCardInvoiceDate(int? cardInvoiceDate)
        {
            if (cardInvoiceDate is null)
                return;

            InvoiceDay = cardInvoiceDate.Value;
        }

        public void SetLimit(decimal? limit)
        {
            if (limit is null)
                return;

            Limit = limit.Value;
        }
        #endregion
        public static CreditCard Create(string name, decimal limit, string number, int invoiceDate) => new CreditCard(name, limit, number, invoiceDate);
    }
}
