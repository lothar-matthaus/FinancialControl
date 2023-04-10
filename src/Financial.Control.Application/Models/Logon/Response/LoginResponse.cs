using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using System.Net;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginResponse : BaseResponse<LoginSuccessResponse, LoginErrorResponse>, IBaseResponse
    {
        public LoginResponse() : base() { }
        private LoginResponse(string message, HttpStatusCode statusCode, LoginSuccessResponse success) : base(message, statusCode, success) { }
        private LoginResponse(string message, HttpStatusCode statusCode, LoginErrorResponse error) : base(message, statusCode, error) { }

        public static LoginResponse AsSuccess(string message, HttpStatusCode statusCode, LoginSuccessResponse success) => new LoginResponse(message, statusCode, success);
        public static LoginResponse AsError(string message, HttpStatusCode statusCode, LoginErrorResponse error) => new LoginResponse(message, statusCode, error);

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = "Erro ao fazer login";
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = LoginErrorResponse.Create(errors);
        }
    }
}
