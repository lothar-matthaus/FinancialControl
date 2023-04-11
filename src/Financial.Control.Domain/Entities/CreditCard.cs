using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities
{
    public class CreditCard : Card
    {
        #region Properties
        public decimal Limit { get; }
        public DateTime PaymentDueDate { get; }
        #endregion

        protected CreditCard() : base() { }
        private CreditCard(string name, decimal limit, string number, DateTime paymentDueDate) : base(name, CardType.Credit, number)
        {
            Limit = limit;
            PaymentDueDate = paymentDueDate;
        }

        public static CreditCard Create(string name, decimal limit, string number, DateTime paymentDueDate) => new CreditCard(name, limit, number, paymentDueDate);
    }
}
