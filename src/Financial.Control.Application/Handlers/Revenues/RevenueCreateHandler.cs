using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models.Revenues.Commands;
using Financial.Control.Domain.Models.Revenues.Response.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    public class RevenueCreateHandler : BaseRequestHandler<RevenueCreateRequest, RevenueCreateResponse>
    {
        public RevenueCreateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<RevenueCreateResponse> Handle(RevenueCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            if (user is null)
                return RevenueCreateResponse.AsError(RevenueMessage.RevenueCreateError(), HttpStatusCode.NotFound, RevenueCreateErrorResponse
                    .Create(UserMessage.UserNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { GenericMessage.IdNotExists(_app.CurrentUser.Id) }) }));
           
            Revenue revenue = request;

            user.AddRevenue(revenue);

            return RevenueCreateResponse.AsSuccess(RevenueMessage.RevenueCreateSuccess(), HttpStatusCode.Created, RevenueCreateSuccessResponse.Create(request));
        }
    }
}
