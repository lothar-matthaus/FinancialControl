using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Logon.Response;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginResponse : BaseResponse<ILoginSuccessResponse, ILoginErrorResponse>, ILoginResponse
    {
        public LoginResponse() { }

        private LoginResponse(string message, HttpStatusCode statusCode, ILoginSuccessResponse success) : base(message, statusCode, success) { }
        private LoginResponse(string message, HttpStatusCode statusCode, ILoginErrorResponse error) : base(message, statusCode, error) { }

        public static LoginResponse AsSuccess(string message, HttpStatusCode statusCode, ILoginSuccessResponse success) => new LoginResponse(message, statusCode, success);
        public static LoginResponse AsError(string message, HttpStatusCode statusCode, ILoginErrorResponse error) => new LoginResponse(message, statusCode, error);

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = LoginMessage.LoginError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = LoginErrorResponse.Create(message, errors);
        }
    }
}
