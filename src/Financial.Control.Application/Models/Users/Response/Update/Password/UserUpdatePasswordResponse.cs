using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Users.Response.Update.Password;
using Financial.Control.Domain.Models.Users.Response.Update.User;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Update.Password
{
    public sealed class UserUpdatePasswordResponse : BaseResponse<IUserUpdatePasswordSuccessResponse, IUserUpdatePasswordErrorResponse>, IUserUpdateResponse
    {
        public UserUpdatePasswordResponse() { }
        private UserUpdatePasswordResponse(string message, HttpStatusCode statusCode, IUserUpdatePasswordSuccessResponse success) : base(message, statusCode, success) { }
        private UserUpdatePasswordResponse(string message, HttpStatusCode statusCode, IUserUpdatePasswordErrorResponse error) : base(message, statusCode, error) { }

        #region MyRegion
        public static UserUpdatePasswordResponse AsSuccess(string message, HttpStatusCode statusCode, IUserUpdatePasswordSuccessResponse success) => new UserUpdatePasswordResponse(message, statusCode, success);
        public static UserUpdatePasswordResponse AsError(string message, HttpStatusCode statusCode, IUserUpdatePasswordErrorResponse error) => new UserUpdatePasswordResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserUpdatePasswordError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserUpdatePasswordErrorResponse.Create(message, errors);
        }
    }
}
