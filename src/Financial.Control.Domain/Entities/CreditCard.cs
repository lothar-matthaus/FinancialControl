using Financial.Control.Domain.Entities.Base;
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
        private CreditCard(string name, string flag, decimal limit, string number, DateTime paymentDueDate) : base(name, flag, CardType.Credit, number)
        {
            Limit = limit;
            PaymentDueDate = paymentDueDate;
        }

        public static CreditCard Create(string name, string flag, decimal limit, string number, DateTime paymentDueDate) => new CreditCard(name, flag, limit, number, paymentDueDate);
    }
}
