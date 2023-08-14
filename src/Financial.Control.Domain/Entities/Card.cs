using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Enums;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Domain.Entities
{
    public abstract class Card : BaseEntity
    {
        #region Private properties
        private string _name;
        private CardFlag _flag;
        private CardType _type;
        private string _number;
        #endregion

        #region Properties

        public string Number
        {
            get { return _number; }
            private set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Number), "O número do cartão deve ser informado."),
                         ifValid: () => _number = value);

                Validate(isInvalidIf: (!IsValidCardNumber(value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Number), "O número do cartão informado é inválido."),
                         ifValid: () => _number = value);
            }
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Name), "O nome do cartão deve ser informado."),
                         ifValid: () => _name = value);

                Validate(isInvalidIf: (value.Length < 4),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Name), "O nome do cartão deve ter pelo menos 4 caracteres."),
                         ifValid: () => _name = value);

            }
        }

        public CardFlag Flag
        {
            get { return _flag; }
            private set
            {
                Validate(isInvalidIf: (!Enum.IsDefined(typeof(CardFlag), value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Flag), "A bandeira do cartão informado não é suportado pelo sistema."),
                         ifValid: () => _flag = value);
            }
        }
        public CardType Type
        {
            get { return _type; }
            private set
            {
                Validate(isInvalidIf: (!Enum.IsDefined(typeof(CardType), value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Type), "O tipo de cartão informado não é válido."),
                         ifValid: () => _type = value);
            }
        }
        #endregion

        #region Navigation
        public User User { get; }
        public long UserId { get; }

        public ICollection<Expense> Expenses { get; private set; }
        #endregion

        public Card() { }
        protected Card(string name, CardType cardType, string number)
        {
            Name = name;
            Number = FormatCardNumber(number);
            Flag = SetCardFlag(FormatCardNumber(number));
            Type = cardType;
        }

        #region Private Methods
        private string FormatCardNumber(string number) => Regex.Replace(number, @"\D", "");
        private bool IsValidCardNumber(string number)
        {
            string cleanedNumber = new string(number.Where(char.IsDigit).ToArray());

            if (cleanedNumber.Length < 13 || cleanedNumber.Length > 19)
            {
                return false; // O número do cartão deve ter entre 13 e 19 dígitos após a limpeza
            }

            int sum = 0;
            bool shouldDouble = false;

            for (int i = cleanedNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cleanedNumber[i].ToString());

                if (shouldDouble)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                shouldDouble = !shouldDouble;
            }

            return sum % 10 == 0;
        }
        private CardFlag SetCardFlag(string number) => CardFlagPattern.Patterns
                    .Where(pattern => Regex.IsMatch(number, pattern.Value))
                    .Select(pattern => pattern.Key)
                    .FirstOrDefault();
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
