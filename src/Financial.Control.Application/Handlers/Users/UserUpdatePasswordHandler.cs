using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Update.Password;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    internal class UserUpdatePasswordHandler : BaseRequestHandler<UserUpdatePasswordRequest, UserUpdatePasswordResponse>
    {
        public UserUpdatePasswordHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public override async Task<UserUpdatePasswordResponse> Handle(UserUpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                return UserUpdatePasswordResponse.AsError(UserMessage.UserUpdatePasswordError(), HttpStatusCode.BadRequest, UserUpdatePasswordErrorResponse
                    .Create(UserMessage.UserNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(user?.Id) }) }));

            bool passwordWasUpdated = user.Account.SetPassword(request.NewPassword, request.CurrentPassword);

            if (!passwordWasUpdated)
                return UserUpdatePasswordResponse.AsError(UserMessage.UserUpdatePasswordError(), HttpStatusCode.BadRequest, UserUpdatePasswordErrorResponse
                    .Create(UserMessage.PasswordNotEquals(), new List<Notification> { Notification.Create(request.GetType().Name, request.CurrentPassword.GetType().Name, new string[] { }) }));

            _app.UnitOfWork.Users.Update(user);

            return UserUpdatePasswordResponse.AsSuccess(UserMessage.UserUpdatePasswordSuccess(), HttpStatusCode.OK, UserUpdatePasswordSuccessResponse.Create(user));
        }
    }
}
