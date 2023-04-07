using System.Net;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateResponse : BaseResponse<UserCreateSuccessResponse, UserCreateErrorResponse>
    {
        private UserCreateResponse(string message, HttpStatusCode statusCode, UserCreateSuccessResponse success) : base(message, statusCode, success) { }
        private UserCreateResponse(string message, HttpStatusCode statusCode, UserCreateErrorResponse error) : base(message, statusCode, error) { }

        #region Behaviors
        public static UserCreateResponse AsSuccess(string message, HttpStatusCode statusCode, UserCreateSuccessResponse success) => new UserCreateResponse(message, statusCode, success);
        public static UserCreateResponse AsError(string message, HttpStatusCode statusCode, UserCreateErrorResponse error) => new UserCreateResponse(message, statusCode, error);
        #endregion
    }
}
