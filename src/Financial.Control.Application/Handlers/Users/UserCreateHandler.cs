using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : BaseRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public UserCreateHandler(IApplication application,
            IHttpContextAccessor httpContextAccessor) :
            base(application, httpContextAccessor)
        { }

        public async override Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            bool emailAlreadyExists = await _app.UnitOfWork.Users.EmailAlreadyExists(request.Email);

            if (emailAlreadyExists)
                _app.Services.NotificationManager.AddNotification(Notification.Create(request.GetType().Name, nameof(request.Email), UserMessage.UserEmailAlreadyExists(request.Email)));

            Account account = Account.Create(request.Email, request.ProfilePictureUrl, request.Password, request.ConfirmPassword);
            User user = User.Create(request.Name, account);

            if (!user.IsValid())
                _app.Services.NotificationManager.AddNotifications(user.GetNotifications());

            await _app.UnitOfWork.Users.AddAsync(user, cancellationToken);

            return UserCreateResponse.AsSuccess(UserMessage.UserCreateSuccess(), HttpStatusCode.Created, UserCreateSuccessResponse.Create(user));
        }
    }
}
