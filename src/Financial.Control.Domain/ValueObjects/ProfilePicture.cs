using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Domain.ValueObjects
{
    public record ProfilePicture : BaseValueObject
    {
        #region Private properties
        private string _value;
        #endregion

        public string Value
        {
            get { return _value; }
            set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "A URL da foto de perfil deve ser informada."),
                         ifValid: () => _value = value);

                Validate(isInvalidIf: (!Regex.IsMatch(value, UrlPattern.URL)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O formato da URL está incorreta."),
                         ifValid: () => _value = value);
            }
        }


        protected ProfilePicture() { }
        private ProfilePicture(string value)
        {
            Value = value;
        }

        public static ProfilePicture Create(string value) => new ProfilePicture(value);
    }
}
