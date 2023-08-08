using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Extensions;
using Financial.Control.Domain.ValueObjects.Base;

namespace Financial.Control.Domain.ValueObjects
{
    public record Payment : BaseValueObject
    {
        #region Private properties
        private decimal _value;
        private int _installment = 1;
        private PaymentType _paymentType;
        #endregion

        #region Properties
        public decimal Value
        {
            get { return _value; }
            private set
            {
                Validate(value == default, () => Notification.Create(this.GetType().Name, nameof(Value), "O valor da despesa deve ser informado."), () => _value = value / Installment);
            }
        }

        public decimal TotalValue { get; }

        public PaymentType PaymentType
        {
            get { return _paymentType; }
            private set
            {
                Validate(!Enum.IsDefined(PaymentType), () => Notification.Create(this.GetType().Name, nameof(Value), "A forma de pagamento selectionada não é válida."), () => _paymentType = value);
            }
        }

        public int Installment
        {
            get { return _installment; }
            private set
            {
                Validate((value < 1), () => Notification.Create(this.GetType().Name, nameof(Value), "O pagamento deve ter ao menos uma prestação."), () => _installment = value);
                Validate((value == 1 && PaymentType != PaymentType.Money), () => Notification.Create(this.GetType().Name, nameof(Value), $"A forma de pagamento {PaymentType.GetDescription()} deve ser à vista."), () => _installment = value);
            }
        }

        #endregion

        protected Payment() { }

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
        public static Payment Create(decimal value, int installment, PaymentType paymentType) => new Payment(value, installment, paymentType);
        #endregion
    }
}
