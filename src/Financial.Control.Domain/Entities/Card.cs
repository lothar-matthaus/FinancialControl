using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Domain.Entities
{
    public abstract class Card : BaseEntity
    {
        #region Properties
        public string Name { get; private set; }
        public CardFlag Flag { get; private set; }
        public CardType CardType { get; }
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
        protected Card(string name, CardType cardType, string cardNumber)
        {
            CardNumber = cardNumber.Replace(" ", "");
            Flag = SetCardFlag(CardNumber);
            CardType = cardType;
            Name = name;
        }

        #region Private Methods
        protected CardFlag SetCardFlag(string cardNumber) => CardFlagPattern.Patterns.Where(pattern => Regex.IsMatch(cardNumber, pattern.Value)).Select(pattern => pattern.Key).FirstOrDefault();
        #endregion

        #region Behaviors
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
        #endregion
    }
}
