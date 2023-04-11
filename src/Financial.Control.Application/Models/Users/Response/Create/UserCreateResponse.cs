using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Users.Response.Create;
using System.Net;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateResponse : BaseResponse<IUserCreateSuccessResponse, IUserCreateErrorResponse>, IUserCreateResponse
    {
        public UserCreateResponse() : base() { }

        public UserCreateResponse(string message, HttpStatusCode statusCode, IUserCreateSuccessResponse success) : base(message, statusCode, success)
        {
        }
        public UserCreateResponse(string message, HttpStatusCode statusCode, IUserCreateErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static UserCreateResponse AsSuccess(string message, HttpStatusCode statusCode, IUserCreateSuccessResponse success) => new UserCreateResponse(message, statusCode, success);
        public static UserCreateResponse AsError(string message, HttpStatusCode statusCode, IUserCreateErrorResponse error) => new UserCreateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserCreateErrorResponse.Create(errors);
        }
    }
}
