using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Update;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    public sealed class RevenueUpdateHandler : BaseRequestHandler<RevenueUpdateRequest, RevenueUpdateResponse>
    {
        public RevenueUpdateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<RevenueUpdateResponse> Handle(RevenueUpdateRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _app.UnitOfWork.Revenues
                .Query(rev => rev.Id.Equals(request.Id) &&
                      (_app.CurrentUser.Id.Equals(rev.User.Id)))
                .FirstOrDefaultAsync(cancellationToken);

            if (revenue is null)
                return RevenueUpdateResponse.AsError(RevenueMessage.RevenueUpdateError(), HttpStatusCode.BadRequest,
                    RevenueUpdateErrorResponse.Create(RevenueMessage.RevenueGetNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(request.Id) }) }));

            revenue.SetName(request.Name);
            revenue.SetValue(request.Value);

            _app.UnitOfWork.Revenues.Update(revenue);

            return RevenueUpdateResponse.AsSuccess(RevenueMessage.RevenueUpdateSuccess(), HttpStatusCode.OK, RevenueUpdateSuccessResponse.Create(revenue));
        }
    }
}
