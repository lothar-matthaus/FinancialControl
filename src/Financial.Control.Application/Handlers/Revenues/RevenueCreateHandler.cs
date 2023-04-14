using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    public class RevenueCreateHandler : AppRequestHandler<RevenueCreateRequest, RevenueCreateResponse>
    {
        public RevenueCreateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<RevenueCreateResponse> Handle(RevenueCreateRequest request)
        {
            User user = _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            if (user is null)
                return RevenueCreateResponse.AsError(RevenueMessage.RevenueCreateError(), HttpStatusCode.NotFound, RevenueCreateErrorResponse
                    .Create(new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { UserMessage.UserNotFound() }) }));

            user.AddRevenue(request);

            return RevenueCreateResponse.AsSuccess(RevenueMessage.RevenueCreateSuccess(), HttpStatusCode.Created, RevenueCreateSuccessResponse.Create(request));
        }
    }
}
