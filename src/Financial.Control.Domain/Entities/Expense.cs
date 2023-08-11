using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Domain.Entities
{
    public class Expense : BaseEntity
    {
        #region Private Properties
        private string _description;
        private Card _card;
        private Category _category;
        private Payment _payment;
        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
            set
            {
                Validate(string.IsNullOrWhiteSpace(value), () => Notification.Create(this.GetType().Name, nameof(Description), "A despesa deve ter uma descrição"), () => _description = value);
                Validate(value.Length < 5, () => Notification.Create(this.GetType().Name, nameof(Description), "A descrição da despesa deve conter ao menos 5 caracteres."), () => _description = value);
            }
        }

        public bool PaidOut { get; }
        public Payment Payment
        {
            get { return _payment; }
            set
            {
                Validate(isInvalidIf: value is null,
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Payment), $"A despesa precisa ter um pagamento atrelado"),
                         ifValid: () => _payment = value);
            }
        }

        #endregion

        #region Navigation
        public Card Card
        {
            get { return _card; }
            set
            {
                Validate(isInvalidIf: (Payment?.PaymentType != PaymentType.Money && value is null),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Card), $"A forma de pagamento 'à vista' precisa de um cartão válido."),
                         ifValid: () => _card = value);

                Validate(isInvalidIf: (Payment?.PaymentType == PaymentType.DebitCard && Payment?.Installment > 1),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Card), $"Não é possível parcelar uma despesa com pagamento tipo 'Cartão de Débito'."),
                         ifValid: () => _card = value);
            }
        }
        public long? CardId { get; }

        public Category Category
        {
            get { return _category; }
            set
            {
                Validate(isInvalidIf: (value is null),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Category), "A categoria da despesa é obrigatória"),
                         ifValid: () => _category = value);
            }
        }

        public long CategoryId { get; }
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Expense() { }
        private Expense(string description, Category category, Card card, decimal value, int installment, PaymentType paymentType)
        {
            Description = description;
            Category = category;
            Card = card;
            Payment = Payment.Create(value, installment, paymentType);
            PaidOut = false;

            if (!Payment.IsValid())
                _notifications.AddRange(Payment.GetNotifications());
        }

        public static Expense Create(string description, Category category, Card card, decimal value, int installment, PaymentType paymentType) => new Expense(description, category, card, value, installment, paymentType);
    }
}
