using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Records
{
    public record Payment
    {
        #region Properties
        public decimal Value { get; }
        public decimal TotalValue { get; }
        public PaymentType PaymentType { get; }
        public int Installment { get; }
        #endregion

        protected Payment() { }
        private Payment(decimal value, PaymentType paymentType)
        {
            Value = value;
            PaymentType = paymentType;
        }
        private Payment(decimal value, int installment, PaymentType paymentType)
        {
            Value = value;
            PaymentType = paymentType;
            Installment = installment;
        }

        #region Behaviors
        public decimal GetTotalValue() => Math.Round(Value * Installment);
        #endregion

        #region Factory
        public static Payment Create(decimal value, int installment, PaymentType paymentType)
        {
            if (paymentType == PaymentType.CreditCard)
                return new Payment((value / installment), installment, paymentType);
            else
                return new Payment(value, paymentType);
        }
        #endregion
    }
}
