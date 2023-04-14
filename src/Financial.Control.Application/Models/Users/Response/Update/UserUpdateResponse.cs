using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users.Response.Update;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Update
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

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserUpdateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserUpdateErrorResponse.Create(errors);
        }
    }
}
