using System.Security.Cryptography;
using System.Text;

namespace Financial.Control.Domain.Records
{
    public record Password
    {
        public string Salt { get; private set; }
        public string Value { get; private set; }
        public string PlainText { get; }

        protected Password() { }
        private Password(string plainText)
        {
            Salt = GeneratePasswordSalt();
            Value = GenerateHash(plainText);
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

        public static Password Create(string plainText) => new Password(plainText);
        public static Password Create() => new Password("");
    }
}