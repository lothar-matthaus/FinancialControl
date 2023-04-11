using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Records
{
    public record Payment
    {
        #region Properties
        public decimal Value { get; }
        public decimal TotalValue { get; }
        public PaymentType PaymentType { get; }
        public int Instalment { get; }
        #endregion

        protected Payment() { }
        public Payment(decimal value, PaymentType paymentType)
        {
            Value = value;
            PaymentType = paymentType;
        }
        public Payment(decimal value, int installment, PaymentType paymentType)
        {
            Value = value;
            PaymentType = paymentType;
            Instalment = installment;
        }

        #region Behaviors
        public decimal GetTotalValue() => Math.Round(Value * Instalment);
        #endregion

        #region Factory
        public static Payment Create(decimal value, int installment, PaymentType paymentType) => new Payment(value, installment, paymentType);
        #endregion
    }
}
