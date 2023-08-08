using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Domain.Entities
{
    public class Expense : BaseEntity
    {
        #region Private Properties
        private string _description;
        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
            set
            {
                Validate(string.IsNullOrWhiteSpace(value), () => Notification.Create(this.GetType().Name, nameof(Description), "A despesa deve ter uma descrição"), () => _description = value);
                Validate(value.Length > 5, () => Notification.Create(this.GetType().Name, nameof(Description), "A descrição da despesa deve conter ao menos 5 caracteres."), () => _description = value);
            }
        }

        public bool PaidOut { get; }
        public Payment Payment { get; }
        #endregion

        #region Navigation
        public Card Card { get; }
        public long? CardId { get; }
        public Category Category { get; }
        public long CategoryId { get; }
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Expense() { }
        private Expense(string description, Category category, Card card, Payment payment)
        {
            Description = description;
            Category = category;
            Card = card;
            Payment = payment;
            PaidOut = false;
        }

        public static Expense Create(string description, Category category, Card card, Payment payment) => new Expense(description, category, card, payment);
    }
}
