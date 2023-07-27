using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Delete;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    internal class RevenueDeleteHandler : BaseRequestHandler<RevenueDeleteRequest, RevenueDeleteResponse>
    {
        public RevenueDeleteHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }
        public override async Task<RevenueDeleteResponse> Handle(RevenueDeleteRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _app.UnitOfWork.Revenues.Query(rev => rev.Id.Equals(request.Id) && rev.User.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            if (revenue is null)
                return RevenueDeleteResponse.AsError(RevenueMessage.RevenueDeleteError(), HttpStatusCode.BadRequest, RevenueDeleteErrorResponse
                    .Create(RevenueMessage.RevenueGetNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(request.Id) }) }));

            _app.UnitOfWork.Revenues.Delete(revenue);

            return RevenueDeleteResponse.AsSuccess(RevenueMessage.RevenueDeleteSuccess(), HttpStatusCode.OK, RevenueDeleteSuccessResponse.Create(revenue));
        }
    }
}
