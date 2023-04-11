using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : AppRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public UserCreateHandler(IApplication application,
            IHttpContextAccessor httpContextAccessor) :
            base(application, httpContextAccessor)
        { }

        public async override Task<UserCreateResponse> Handle(UserCreateRequest request)
        {
            bool emailAlreadyExists = _app.UnitOfWork.Users.Query(us => us.Email.Value.Equals(request.Email)).Any();

            if (emailAlreadyExists)
                return UserCreateResponse.AsError(UserMessage.UserCreateError(), HttpStatusCode.Conflict,
                    UserCreateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, nameof(request.Email), new string[] { UserMessage.UserEmailAlreadyExists(request.Email) })
                    }));

            User user = User.Create(request.Name, request.Email, request.ProfilePictureUrl, request.Password);
            _app.UnitOfWork.Users.Add(user);

            return UserCreateResponse.AsSuccess(UserMessage.UserCreateSuccess(), HttpStatusCode.Created, UserCreateSuccessResponse.Create(user));
        }
    }
}
