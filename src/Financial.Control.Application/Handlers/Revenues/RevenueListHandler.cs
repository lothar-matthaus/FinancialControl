using Financial.Control.Application.Models.Revenues;
using Financial.Control.Application.Models.Revenues.Queries;
using Financial.Control.Application.Models.Revenues.Response.List;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    internal class RevenueListHandler : BaseRequestHandler<RevenueListRequest, RevenueListResponse>
    {
        public RevenueListHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<RevenueListResponse> Handle(RevenueListRequest request, CancellationToken cancellationToken)
        {
            DateTime dateFilter;
            DateTime.TryParse($"{request.Month}/{request.Year}", out dateFilter);

            IReadOnlyCollection<Revenue> revenues = await _unitOfWork.Revenues
                .Query(rev => rev.User.Id.Equals(_applicationUser.Id) &&
                      (dateFilter == default || rev.Date.Equals(dateFilter))
                ).ToListAsync(cancellationToken);

            return RevenueListResponse.AsSuccess(revenues.Any() ? RevenueMessage.RevenueListSuccess() : RevenueMessage.RevenueListNotFound(),
                HttpStatusCode.OK, RevenueListSuccessResponse.Create(revenues.ToList().ConvertAll(rev => RevenueModel.Create(rev)))); ;
        }
    }
}
