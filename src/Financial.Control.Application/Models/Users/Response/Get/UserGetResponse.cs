using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.Constants;

namespace Financial.Control.Application.Models.Users.Response.Get
{
    public class UserGetResponse : BaseResponse<UserGetSuccessResponse, UserGetErrorResponse>, IBaseResponse
    {
        public UserGetResponse()
        {
        }

        private UserGetResponse(string message, HttpStatusCode statusCode, UserGetSuccessResponse success) : base(message, statusCode, success)
        {
        }

        private UserGetResponse(string message, HttpStatusCode statusCode, UserGetErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static UserGetResponse AsSuccess(string message, HttpStatusCode statusCode, UserGetSuccessResponse success) => new UserGetResponse(message, statusCode, success);
        public static UserGetResponse AsError(string message, HttpStatusCode statusCode, UserGetErrorResponse error) => new UserGetResponse(message, statusCode, error);

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = UserMessage.UserGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = UserGetErrorResponse.Create(errors);
        }
        #endregion
    }
}
