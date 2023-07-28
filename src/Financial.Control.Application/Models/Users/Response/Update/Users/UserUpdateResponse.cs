using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users.Response.Update.User;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Update.Users
{
    public class UserUpdateResponse : BaseResponse<IUserUpdateSuccessResponse, IUserUpdateErrorResponse>, IBaseResponse
    {
        public UserUpdateResponse() : base()
        {
        }

        public UserUpdateResponse(string message, HttpStatusCode statusCode, IUserUpdateSuccessResponse success) : base(message, statusCode, success)
        {
        }
        public UserUpdateResponse(string message, HttpStatusCode statusCode, IUserUpdateErrorResponse error) : base(message, statusCode, error)
        {
        }

        public static UserUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, IUserUpdateSuccessResponse success) => new UserUpdateResponse(message, statusCode, success);
        public static UserUpdateResponse AsError(string message, HttpStatusCode statusCode, IUserUpdateErrorResponse error) => new UserUpdateResponse(message, statusCode, error);

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserUpdateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserUpdateErrorResponse.Create(message, errors);
        }
    }
}
