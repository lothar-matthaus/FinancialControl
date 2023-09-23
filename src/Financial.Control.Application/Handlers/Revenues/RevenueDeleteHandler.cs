using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Revenues;
using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Delete;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    internal class RevenueDeleteHandler : BaseRequestHandler<RevenueDeleteRequest, RevenueDeleteResponse>
    {
        public RevenueDeleteHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }
        public override async Task<RevenueDeleteResponse> Handle(RevenueDeleteRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _unitOfWork.Revenues
                .Query(rev => rev.Id.Equals(request.Id) &&
                      (rev.User.Id.Equals(_applicationUser.Id)))
                .FirstOrDefaultAsync(cancellationToken);

            if (revenue is null)
                return RevenueDeleteResponse.AsError(RevenueMessage.RevenueDeleteError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(RevenueMessage.RevenueGetNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id)) }));

            _unitOfWork.Revenues.Delete(revenue);

            return RevenueDeleteResponse.AsSuccess(RevenueMessage.RevenueDeleteSuccess(), HttpStatusCode.OK, SuccessResponse<IRevenueModel>.Create(RevenueModel.Create(revenue))); ;
        }
    }
}
