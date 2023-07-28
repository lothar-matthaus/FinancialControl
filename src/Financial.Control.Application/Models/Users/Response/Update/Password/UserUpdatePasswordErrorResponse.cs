using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Users.Response.Update.Password;

namespace Financial.Control.Application.Models.Users.Response.Update.Password
{
    public sealed class UserUpdatePasswordErrorResponse : BaseErrorResponse, IUserUpdatePasswordErrorResponse
    {
        private UserUpdatePasswordErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static UserUpdatePasswordErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new UserUpdatePasswordErrorResponse(message, errors);
        #endregion
    }
}
