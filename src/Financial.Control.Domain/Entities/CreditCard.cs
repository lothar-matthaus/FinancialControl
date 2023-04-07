using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enum;

namespace Financial.Control.Domain.Entities
{
    public class CreditCard : Card
    {
        #region Properties
        public decimal Limit { get; }
        public DateTime PaymentDueDate { get; }
        #endregion

        protected CreditCard() : base(string.Empty, CardType.Credit, string.Empty) { }
        private CreditCard(string flag, decimal limit, string number) : base(flag, CardType.Credit, number)
        {
            Limit = limit;
            PaymentDueDate = DateTime.Now.AddMonths(1);
        }

        public static CreditCard Create(string flag, decimal limit, string number) => new CreditCard(flag, limit, number);
    }
}
