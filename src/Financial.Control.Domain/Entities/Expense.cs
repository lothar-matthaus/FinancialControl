using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class Expense : BaseEntity
    {
        #region Properties
        public string Description { get; }
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
