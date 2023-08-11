using Financial.Control.Application.Models.Revenues.Queries;
using Financial.Control.Application.Models.Revenues.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    public sealed class RevenueGetHandler : BaseRequestHandler<RevenueGetRequest, RevenueGetResponse>
    {
        public RevenueGetHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<RevenueGetResponse> Handle(RevenueGetRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _unitOfWork.Revenues
                .Query(rev => rev.Id.Equals(request.Id) && rev.User.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            if (revenue is null)
                return RevenueGetResponse.AsError(RevenueMessage.RevenueGetError(), HttpStatusCode.BadRequest, RevenueGetErrorResponse
                    .Create(RevenueMessage.RevenueGetNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "RevenueId", GenericMessage.IdNotExists(request.Id)) }));

            return RevenueGetResponse.AsSuccess(RevenueMessage.RevenueGetSuccess(), HttpStatusCode.Created, RevenueGetSuccessResponse.Create(revenue));
        }
    }
}
