using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        #region Private Properties
        private string _name;
        private decimal _value;
        private DateTime _date;
        #endregion
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Name), "O nome da receita deve ser informado"),
                         ifValid: () => _name = value);

                Validate(isInvalidIf: (value.Length < 4),
                        ifInvalid: () => Notification.Create(GetType().Name, nameof(Name), "O nome da despesa deve possuir pelo menos 4 caracteres."),
                        ifValid: () => _name = value);
            }
        }
        public decimal Value
        {
            get
            {
                return _value;
            }
            private set
            {
                Validate(isInvalidIf: (value == default),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Value), "A despesa deve possuir um valor."),
                         ifValid: () => _value = value);

                Validate(isInvalidIf: (value < 0),
                        ifInvalid: () => Notification.Create(GetType().Name, nameof(Value), "O valor da despesa não pode ser negativo."),
                        ifValid: () => _value = value);
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            private set
            {
                Validate(isInvalidIf: (value == default),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Value), "A despesa deve possuir um valor."),
                         ifValid: () => _date = value);
            }
        }

        #region Navigation
        public long UserId { get; }
        public User User { get; }
        #endregion

        protected Revenue() { }
        private Revenue(string name, decimal value, DateTime date)
        {

            Name = name;
            Value = value;
            Date = date;
        }

        #region Behaviors
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
        public void SetValue(decimal value)
        {
            if (value is 0)
                return;

            Value = value;
        }
        #endregion

        #region Factory
        public static Revenue Create(string name, decimal revenue, DateTime date) => new Revenue(name, revenue, date);
        #endregion
    }
}
