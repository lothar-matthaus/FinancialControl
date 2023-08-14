using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Models.Users.Response.Get;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetResponse : BaseResponse<ISuccessResponse<IUserModel>, IErrorResponse, IUserModel>, IUserGetResponse
    {
        public UserGetResponse()
        {
        }

        public UserGetResponse(string message, HttpStatusCode statusCode, ISuccessResponse<IUserModel> success) : base(message, statusCode, success)
        {
        }

        public UserGetResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static UserGetResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessResponse<IUserModel> success) => new UserGetResponse(message, statusCode, success);
        public static UserGetResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new UserGetResponse(message, statusCode, error);

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
        #endregion
    }
}
