using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;
using static Financial.Control.Domain.Constants.Patterns;
using System.Text.RegularExpressions;

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

        #region Behaviors
        protected CardFlag SetCardFlag(string cardNumber)
        {
            if (Regex.IsMatch(CardNumber, CardFlagPattern.Mastercard)) return CardFlag.MasterCard;
            else if (Regex.IsMatch(CardNumber, CardFlagPattern.Hipercard)) return CardFlag.Hipercard;
            else if (Regex.IsMatch(CardNumber, CardFlagPattern.Visa)) return CardFlag.Visa;
            else if (Regex.IsMatch(CardNumber, CardFlagPattern.JBC)) return CardFlag.JBC;

            return CardFlag.Alelo;
        }
        #endregion
    }
}
