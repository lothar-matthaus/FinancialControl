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
                return UserCreateResponse.AsError(UserMessage.UserCreateError(), HttpStatusCode.Conflict, UserCreateErrorResponse
                    .Create(UserMessage.UserEmailAlreadyExists(request.Email), new List<Notification>() { Notification.Create(request.GetType().Name, nameof(request.Email), GenericMessage.EmailConflict()) }));

            User user = request;
            _app.UnitOfWork.Users.AddAsync(user, cancellationToken);

            return UserCreateResponse.AsSuccess(UserMessage.UserCreateSuccess(), HttpStatusCode.Created, UserCreateSuccessResponse.Create(user));
        }
    }
}
