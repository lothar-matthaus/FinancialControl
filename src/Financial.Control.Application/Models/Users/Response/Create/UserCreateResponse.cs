using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Models.Users.Response.Create
{
    public class UserCreateResponse : BaseResponse<UserCreateSuccessResponse, UserCreateErrorResponse>, IBaseResponse
    {
        public UserCreateResponse() : base() { }
        private UserCreateResponse(string message, HttpStatusCode statusCode, UserCreateSuccessResponse success) : base(message, statusCode, success) { }
        private UserCreateResponse(string message, HttpStatusCode statusCode, UserCreateErrorResponse error) : base(message, statusCode, error) { }

        public static UserCreateResponse AsSuccess(string message, HttpStatusCode statusCode, UserCreateSuccessResponse success) => new UserCreateResponse(message, statusCode, success);
        public static UserCreateResponse AsError(string message, HttpStatusCode statusCode, UserCreateErrorResponse error) => new UserCreateResponse(message, statusCode, error);

        public void SetInvalidState(IReadOnlyCollection<Notification> errors)
        {
            Message = "Erro ao criar o usuário.";
            StatusCode = HttpStatusCode.BadRequest;
            Error = UserCreateErrorResponse.Create(errors);
        }
        #region Behaviors

        #endregion
    }
}
