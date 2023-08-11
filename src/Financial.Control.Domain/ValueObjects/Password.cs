using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.ValueObjects.Base;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Domain.ValueObjects
{
    public record Password : BaseValueObject
    {
        #region Private properties
        private string _salt;
        private string _value;
        private string _plainText;
        private string _confirmationPlainText;
        #endregion

        public string PlainText
        {
            get => _plainText;
            set
            {
                Validate(isInvalidIf: string.IsNullOrWhiteSpace(value),
                         ifInvalid: () => Notification.Create(GetType().Name, "Password", "A senha deve ser informada."),
                         ifValid: () => _plainText = value);

                Validate(isInvalidIf: !string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, PasswordPatterns.Password),
                         ifInvalid: () => Notification.Create(GetType().Name, "Password", "A senha deve conter pelo menos: 1 número. 1 caractere especial. 1 letra minúscula. 1 letra maiúscula."),
                         ifValid: () => _plainText = value);
            }
        }
        public string ConfirmationPlainText
        {
            get => _confirmationPlainText;
            set
            {
                Validate(isInvalidIf: string.IsNullOrWhiteSpace(value),
                         ifInvalid: () => Notification.Create(GetType().Name, "ConfirmPassword", "A senha deve ser informada."),
                         ifValid: () => _confirmationPlainText = value);

                Validate(isInvalidIf: !string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, PasswordPatterns.Password),
                         ifInvalid: () => Notification.Create(GetType().Name, "ConfirmPassword", "A confirmação de senha deve conter pelo menos: 1 número. 1 caractere especial. 1 letra minúscula. 1 letra maiúscula."),
                         ifValid: () => _confirmationPlainText = value);

                Validate(isInvalidIf: !string.IsNullOrWhiteSpace(value) && (!_plainText.Equals(value)),
                         ifInvalid: () => Notification.Create(GetType().Name, "ConfirmPassword", "As senhas não se correspondem."),
                         ifValid: () => _confirmationPlainText = value);
            }
        }

        public string Salt
        {
            get => _salt;
            set => Validate(isInvalidIf: string.IsNullOrWhiteSpace(value),
                         ifInvalid: () => Notification.Create(GetType().Name, nameof(Salt), "O SALT da senha não pode ser vazia."),
                         ifValid: () => _salt = value);
        }

        public string Value
        {
            get => _value;
            set => Validate(isInvalidIf: string.IsNullOrWhiteSpace(value),
                        ifInvalid: () => Notification.Create(GetType().Name, nameof(Value), "O HASH do password não foi gerado corretamente."),
                        ifValid: () => _value = value);
        }

        protected Password() { }



        private Password(string passwordPlainText, StringBuilder salt)
        {
            PlainText = passwordPlainText;
            Salt = salt.ToString() ?? string.Empty;
            Value = GenerateHash(passwordPlainText);
        }
        private Password(string passwordPlainText, string passwordConfirmationPlainText)
        {
            PlainText = passwordPlainText;
            ConfirmationPlainText = passwordConfirmationPlainText;
            Salt = GeneratePasswordSalt();
            Value = GenerateHash(passwordPlainText);
        }

        #region Private Methods
        private string GeneratePasswordSalt()
        {
            string chars = "qwertyuiopasdfghjklçzxcvbnmQWERTYUIOPASDFGHJKLÇZXCVBNM!@#$%¨&*()1234567890";

            return new string(Enumerable.Repeat(chars, chars.Length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
        private string GenerateHash(string plainTextPassword)
        {
            byte[] key = Encoding.UTF8.GetBytes(Salt ?? "");
            string hashString;

            using (HMACSHA256 hmac = new(key))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] hash = hmac.ComputeHash(passwordBytes);

                hashString = Convert.ToHexString(hash);
            }

            return hashString;
        }

        #endregion

        #region Behaviors

        public void IsCurrentPasswordMatch(string plainText)
        {
            Validate(isInvalidIf: !plainText.Equals(Value),
                     ifInvalid: () => Notification.Create(GetType().Name, "CurrentPassword", "A senha atual informada não é válida."),
                     ifValid: () => new object());
        }
        #endregion

        #region Factory
        public static Password Create(string passwordPlainText, string passwordConfirmationPlainText)
        {
            return new Password(passwordPlainText, passwordConfirmationPlainText);
        }

        public static Password CreateWithSalt(string passwordPlainText, StringBuilder salt)
        {
            return new Password(passwordPlainText, salt);
        }
        #endregion
    }
}