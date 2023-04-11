using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Logon.Response;
using System.Net;

namespace Financial.Control.Application.Models.Logon.Response
{
    public class LoginResponse : BaseResponse<ILoginSuccessResponse, ILoginErrorResponse>, ILoginResponse
    {
        protected LoginResponse() { }

        private LoginResponse(string message, HttpStatusCode statusCode, ILoginSuccessResponse success) : base(message, statusCode, success) { }
        private LoginResponse(string message, HttpStatusCode statusCode, ILoginErrorResponse error) : base(message, statusCode, error) { }

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
