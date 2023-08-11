using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.ValueObjects;
using System.Text;

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
        private Account(string email, string profilePictureUrl, string plainTextPassword, string confirmPlainText)
        {
            Email = Email.Create(email);
            ProfilePicture = ProfilePicture.Create(profilePictureUrl);
            Password = Password.Create(plainTextPassword, confirmPlainText);
            Status = AccountStatus.Blocked;

            _notifications.AddRange(Email.GetNotifications());
            _notifications.AddRange(ProfilePicture.GetNotifications());
            _notifications.AddRange(Password.GetNotifications());
        }

        #region Behaviors
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            Email = Email.Create(email);
            _notifications.AddRange(Email.GetNotifications());
        }

        public void SetProfilePicture(string profilePictureUrl)
        {
            if (string.IsNullOrWhiteSpace(profilePictureUrl))
                return;

            ProfilePicture = ProfilePicture.Create(profilePictureUrl);
            _notifications.AddRange(ProfilePicture.GetNotifications());
        }
        public void SetToken(UserToken userToken)
        {
            if (userToken is null)
                return;

            Token = UserToken.Create(userToken.AccessToken, userToken.ExpirationTime);
        }

        public void SetPassword(string plainTextPassword, string confirmationPlainText, string currentPasswordPlainText)
        {
            Password currentPassword = Password;

            Password = Password.CreateWithSalt(currentPasswordPlainText, new StringBuilder(currentPassword.Salt));
            Password.IsCurrentPasswordMatch(currentPassword.Value);

            if (Password.IsValid())
                Password = Password.Create(plainTextPassword, confirmationPlainText);

            return;
        }
        #endregion

        public static Account Create(string email, string profilePictureUrl, string plainTextPassword, string confirmPlainText) => new Account(email, profilePictureUrl, plainTextPassword, confirmPlainText);
    }
}
