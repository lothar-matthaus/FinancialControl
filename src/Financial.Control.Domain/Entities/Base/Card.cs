using Financial.Control.Domain.Enum;

namespace Financial.Control.Domain.Entities.Base
{
    public abstract class Card : BaseEntity
    {
        #region Properties
        public string Flag { get; }
        public CardType CardType { get; protected set; }
        #endregion

        #region Navigation
        public User User { get; }
        public long UserId { get; }

        public ICollection<Expense> Expenses { get; private set; }
        #endregion

        protected Card(string flag, CardType cardType)
        {
            Flag = flag;
            CardType = cardType;
        }

    }
}
