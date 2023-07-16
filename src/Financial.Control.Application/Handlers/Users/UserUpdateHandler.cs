using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Update;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserUpdateHandler : BaseRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        public UserUpdateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users
                .Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            bool emailAlreadyExists = await _app.UnitOfWork.Users
                .Query(us => us.Account.Email.Value.Equals(request.Email))
                .AnyAsync();

            if (emailAlreadyExists)
                return UserUpdateResponse.AsError(UserMessage.UserUpdateError(), HttpStatusCode.Conflict,
                    UserUpdateErrorResponse.Create(UserMessage.UserEmailAlreadyExists(request.Email), new List<Notification>() { Notification
                    .Create(request.GetType().Name, nameof(request.Email), new string[] { GenericMessage.EmailConflict()  }) }));

            if (user is null)
                return UserUpdateResponse.AsError(UserMessage.UserUpdateError(), HttpStatusCode.NotFound,
                    UserUpdateErrorResponse.Create(UserMessage.UserNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(_app.CurrentUser.Id) }) }));

            user.SetName(request.Name);
            user.SetEmail(request.Email);
            user.SetProfilePicture(request.ProfilePictureUrl);

            _app.UnitOfWork.Users.Update(user);

            return UserUpdateResponse.AsSuccess(UserMessage.UserUpdateSuccess(), HttpStatusCode.OK, UserUpdateSuccessResponse.Create(user));
        }
    }
}
