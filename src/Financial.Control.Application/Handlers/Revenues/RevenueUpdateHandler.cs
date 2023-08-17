using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Revenues;
using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Update;
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
    public sealed class RevenueUpdateHandler : BaseRequestHandler<RevenueUpdateRequest, RevenueUpdateResponse>
    {
        public RevenueUpdateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<RevenueUpdateResponse> Handle(RevenueUpdateRequest request, CancellationToken cancellationToken)
        {
            Revenue revenue = await _unitOfWork.Revenues
                .Query(rev => rev.Id.Equals(request.Id) &&
                      (_applicationUser.Id.Equals(rev.User.Id)))
                .FirstOrDefaultAsync(cancellationToken);

            if (revenue is null)
                return RevenueUpdateResponse.AsError(RevenueMessage.RevenueUpdateError(), HttpStatusCode.BadRequest,
                    ErrorResponse.Create(RevenueMessage.RevenueGetNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id)) }));

            revenue.SetName(request.Name);
            revenue.SetValue(request.Value);

            _unitOfWork.Revenues.Update(revenue);

            return RevenueUpdateResponse.AsSuccess(RevenueMessage.RevenueUpdateSuccess(), HttpStatusCode.OK, SuccessSingleResponse<IRevenueModel>.Create(RevenueModel.Create(revenue)));
        }
    }
}
