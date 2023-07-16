using Financial.Control.Application.Models.Revenues.Queries.Get;
using Financial.Control.Application.Models.Revenues.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    public sealed class RevenueGetHandler : BaseRequestHandler<RevenueGetRequest, RevenueGetResponse>
    {
        public RevenueGetHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<RevenueGetResponse> Handle(RevenueGetRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _app.UnitOfWork.Revenues
                .Query(rev => rev.Id.Equals(request.RevenueId) && rev.User.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            if (revenue is null)
                return RevenueGetResponse.AsError(RevenueMessage.RevenueGetError(), HttpStatusCode.NotFound, RevenueGetErrorResponse
                    .Create(RevenueMessage.RevenueNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "RevenueId", new string[] { GenericMessage.IdNotExists(request.RevenueId) }) }));

            return RevenueGetResponse.AsSuccess(RevenueMessage.RevenueCreateSuccess(), HttpStatusCode.Created, RevenueGetSuccessResponse.Create(revenue));
        }
    }
}
