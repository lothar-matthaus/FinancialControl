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
        private string _value;
        private string _salt;
        private string _plainText;
        private string _confirmPlainText;
        #endregion

        private string ConfirmPlainText
        {
            get { return _confirmPlainText; }
            set
            {
                Validate(isInvalidIf: (!Regex.IsMatch(value, PasswordPatterns.Password)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "A senha de confirmação deve conter: Pelo menos 8 caracteres. Pelo menos 1 letra maiúscula. Pelo menos uma letra minúscula. Pelo menos 1 caractere especial"),
                         ifValid: () => _confirmPlainText = value);
            }
        }
        public string PlainText
        {
            get { return _plainText; }
            set
            {
                Validate(isInvalidIf: (!value.Equals(ConfirmPlainText)),
                        ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "As senhas não se correspondem."),
                        ifValid: () => _plainText = value);

                Validate(isInvalidIf: (!Regex.IsMatch(value, PasswordPatterns.Password)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "A senha deve conter: Pelo menos 8 caracteres. Pelo menos 1 letra maiúscula. Pelo menos uma letra minúscula. Pelo menos 1 caractere especial"),
                         ifValid: () => _plainText = value);
            }
        }

        public string Salt
        {
            get { return _salt; }
            set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                         ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "O SALT da senha não pode ser vazia."),
                         ifValid: () => _salt = value);
            }
        }

        public string Value
        {
            get { return _value; }
            set
            {
                Validate(isInvalidIf: (string.IsNullOrWhiteSpace(value)),
                        ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Value), "A senha não deve estar vazia."),
                        ifValid: () => _value = GenerateHash(value));
            }
        }

        protected Password() { }

        private Password(string plainText, string salt)
        {
            Salt = salt;
            PlainText = plainText;
            Value = plainText;
        }

        private Password(string plainText, string confirmPlainText, string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
                Salt = GeneratePasswordSalt();
            else
                Salt = salt;

            ConfirmPlainText = confirmPlainText;
            PlainText = plainText;
            Value = plainText;
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
            var key = Encoding.UTF8.GetBytes(Salt);
            string hashString;

            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] hash = hmac.ComputeHash(passwordBytes);

                hashString = Convert.ToHexString(hash);
            }

            return hashString;
        }
        #endregion

        #region Behaviors
        public bool IsMatchPassword(string plainTextPassword)
        {
            string hashedPassword = GenerateHash(plainTextPassword);
            return hashedPassword.Equals(this.Value);
        }
        #endregion

        #region Factory
        public static Password Create(string plainText, string confirmPlainText) => new Password(plainText, confirmPlainText, string.Empty);
        public static Password CreateWithSalt(string plainText, string salt) => new Password(plainText, salt);
        #endregion
    }
}