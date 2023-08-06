using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Entities
{
    public class Account : BaseEntity
    {
        #region Properties
        public Email Email { get; protected set; }
        public ProfilePicture ProfilePicture { get; protected set; }
        public Password Password { get; protected set; }
        public UserToken Token { get; protected set; }
        public AccountStatus Status { get; private set; }
        #endregion

        #region Navigation
        public long UserId { get; }
        public User User { get; }
        #endregion

        public Account() { }
        private Account(string email, string profilePictureUrl, string plainTextPassword)
        {
            Email = Email.Create(email);
            ProfilePicture = ProfilePicture.Create(profilePictureUrl);
            Password = Password.Create(plainTextPassword);
            Status = AccountStatus.Blocked;
        }

        #region Behaviors
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            Email = Email.Create(email);
        }

        public void SetProfilePicture(string profilePictureUrl)
        {
            if (string.IsNullOrWhiteSpace(profilePictureUrl))
                return;

            ProfilePicture = ProfilePicture.Create(profilePictureUrl);
        }
        public void SetToken(UserToken userToken)
        {
            if (userToken is null)
                return;

            Token = UserToken.Create(userToken.AccessToken, userToken.ExpirationTime);
        }

        public bool SetPassword(string plainTextPassword, string currentPasswordPlainText)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword))
                return false;

            Password currentPassword = Password.Create(currentPasswordPlainText, Password.Salt);

            if (!currentPassword.Value.Equals(Password.Value))
                return false;

            Password = Password.Create(plainTextPassword);

            return true;
        }

        #endregion

        public static Account Create(string email, string profilePictureUrl, string plainTextPassword) => new Account(email, profilePictureUrl, plainTextPassword);
    }
}
