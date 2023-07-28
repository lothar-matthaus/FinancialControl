using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users.Response.Get;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetResponse : BaseResponse<IUserGetSuccessResponse, IUserGetErrorResponse>, IBaseResponse
    {
        public UserGetResponse()
        {
        }

        public UserGetResponse(string message, HttpStatusCode statusCode, IUserGetSuccessResponse success) : base(message, statusCode, success)
        {
        }

        public UserGetResponse(string message, HttpStatusCode statusCode, IUserGetErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static UserGetResponse AsSuccess(string message, HttpStatusCode statusCode, IUserGetSuccessResponse success) => new UserGetResponse(message, statusCode, success);
        public static UserGetResponse AsError(string message, HttpStatusCode statusCode, IUserGetErrorResponse error) => new UserGetResponse(message, statusCode, error);

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserGetErrorResponse.Create(message, errors);
        }
        #endregion
    }
}
