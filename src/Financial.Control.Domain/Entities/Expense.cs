using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enum;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class Expense : BaseEntity
    {
        #region MyRegion
        public string Description { get; }
        public bool PaidOut { get; }
        public Payment Payment { get; }
        #endregion

        #region Navigation
        public Card Card { get; }
        public long CardId { get; }
        public Category Category { get; }
        public long CategoryId { get; }
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Expense() { }
        private Expense(string description, User user, Category category, Card card, Payment payment )
        {
            Description = description;
            Category = category;
            Card = card;
            Payment = payment;
            User = user;
        }

        public static Expense Create(string description, User user, Category category, Card card, Payment payment) => new Expense(description, user, category, card, payment);
    }
}
