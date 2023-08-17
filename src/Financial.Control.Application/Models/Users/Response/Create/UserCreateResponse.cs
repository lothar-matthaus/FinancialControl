using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Models.Users.Response.Create;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateResponse : BaseResponse<ISuccessSingleResponse<IUserModel>, IErrorResponse, IUserModel>, IUserCreateResponse
    {
        public UserCreateResponse() : base() { }

        public UserCreateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IUserModel> success) : base(message, statusCode, success)
        {
        }
        public UserCreateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Factory
        public static UserCreateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<IUserModel> success) => new UserCreateResponse(message, statusCode, success);
        public static UserCreateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new UserCreateResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
