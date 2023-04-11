using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities.Base
{
    public abstract class Card : BaseEntity
    {
        #region Properties
        public string Name { get; private set; }
        public string Flag { get; }
        public CardType CardType { get; protected set; }
        public string CardNumber { get; }
        #endregion

        #region Navigation
        public User User { get; }
        public long UserId { get; }

        public ICollection<Expense> Expenses { get; private set; }
        #endregion

        public Card()
        {

        }
        protected Card(string name, string flag, CardType cardType, string cardNumber)
        {
            Flag = flag;
            CardType = cardType;
            CardNumber = cardNumber;
            Name = name;
        }
    }
}
