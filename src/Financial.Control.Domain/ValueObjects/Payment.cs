using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Extensions;
using Financial.Control.Domain.ValueObjects.Base;
using System.Reflection.Metadata.Ecma335;

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
                Validate(isInvalidIf: value == default, 
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O valor da despesa deve ser informado."),
                         ifValid: () => _value = value / Installment);
            }
        }

        public decimal TotalValue { get; }

        public PaymentType PaymentType
        {
            get { return _paymentType; }
            private set
            {
                Validate(!Enum.IsDefined(typeof(Enums.PaymentType), value), () => Notification.Create(this.GetType().Name, nameof(Value), "A forma de pagamento selecionada não é válida."), () => _paymentType = value);
            }
        }

        public int Installment
        {
            get { return _installment; }
            private set
            {
                Validate(isInvalidIf: (value <= 0),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O pagamento deve ter ao menos uma prestação."),
                         ifValid: () => _installment = value);

                Validate(isInvalidIf: (value > 1 && PaymentType != PaymentType.CreditCard),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), $"Não é possível parcelar com a forma de pagamento '{PaymentType.GetDescription()}'"),
                         ifValid: () => _installment = value);
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
