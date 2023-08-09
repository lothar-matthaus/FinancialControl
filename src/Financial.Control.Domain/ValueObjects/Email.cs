using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Domain.ValueObjects
{
    public record Email : BaseValueObject
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O endereço de e-mail deve ser informado."),
                         ifValid: () => _value = value);

                Validate(isInvalidIf: (!Regex.IsMatch(value, EmailPattern.Email)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O e-mail informado é inválido."),
                         ifValid: () => _value = value);
            }
        }

        protected Email() { }
        private Email(string value)
        {
            Value = value;
        }
        public static Email Create(string value) => new Email(value);
    }
}
