using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserGetHandler : BaseRequestHandler<UserGetRequest, UserGetResponse>
    {
        public UserGetHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<UserGetResponse> Handle(UserGetRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users
                .Query(us => us.Id.Equals(_app.CurrentUser.Id)).Include(user => user.Account)
                .FirstOrDefaultAsync();

            if (user is null)
                return UserGetResponse.AsError(UserMessage.UserGetError(), HttpStatusCode.NotFound, UserGetErrorResponse
                    .Create(UserMessage.UserNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(_app.CurrentUser.Id)) }));

            return UserGetResponse.AsSuccess(UserMessage.UserGetSuccess(), HttpStatusCode.OK, UserGetSuccessResponse.Create(user));
        }
    }
}
