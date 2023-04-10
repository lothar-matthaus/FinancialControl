using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using System.Net;

namespace Financial.Control.Application.Models.Users.Response.Update
{
    public class UserUpdateResponse : BaseResponse<UserUpdateSuccessResponse, UserUpdateErrorResponse>, IBaseResponse
    {
        public UserUpdateResponse() : base()
        {
        }

        public UserUpdateResponse(string message, HttpStatusCode statusCode, UserUpdateSuccessResponse success) : base(message, statusCode, success)
        {
        }

        public UserUpdateResponse(string message, HttpStatusCode statusCode, UserUpdateErrorResponse error) : base(message, statusCode, error)
        {
        }

        public static UserUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, UserUpdateSuccessResponse success) => new UserUpdateResponse(message, statusCode, success);
        public static UserUpdateResponse AsError(string message, HttpStatusCode statusCode, UserUpdateErrorResponse error) => new UserUpdateResponse(message, statusCode, error);

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = "Erro ao atualizar o usuário.";
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserUpdateErrorResponse.Create(errors);
        }
    }
}
