using Financial.Control.Application.Models.Revenues.Commands;
using Financial.Control.Application.Models.Revenues.Response.Create;
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
    public class RevenueCreateHandler : BaseRequestHandler<RevenueCreateRequest, RevenueCreateResponse>
    {
        public RevenueCreateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<RevenueCreateResponse> Handle(RevenueCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users.Query(us => us.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                return RevenueCreateResponse.AsError(RevenueMessage.RevenueCreateError(), HttpStatusCode.BadRequest, RevenueCreateErrorResponse
                    .Create(UserMessage.UserNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(_applicationUser.Id)) }));

            user.AddRevenue(request);

            _unitOfWork.Users.Update(user);

            return RevenueCreateResponse.AsSuccess(RevenueMessage.RevenueCreateSuccess(), HttpStatusCode.Created, RevenueCreateSuccessResponse.Create(request));
        }
    }
}
