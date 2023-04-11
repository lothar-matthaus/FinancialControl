using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserGetHandler : AppRequestHandler<UserGetRequest, UserGetResponse>
    {
        public UserGetHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<UserGetResponse> Handle(UserGetRequest request)
        {
            User user = _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id)).FirstOrDefault();

            if (user is null)
                return UserGetResponse.AsError(UserMessage.UserGetError(), HttpStatusCode.NotFound, UserGetErrorResponse.Create(new List<Notification>()
                {
                    Notification.Create(request.GetType().Name, string.Empty, new string[] { UserMessage.UserNotFound() })
                }));

            return UserGetResponse.AsSuccess(UserMessage.UserGetSuccess(), HttpStatusCode.OK, UserGetSuccessResponse.Create(user));
        }
    }
}
