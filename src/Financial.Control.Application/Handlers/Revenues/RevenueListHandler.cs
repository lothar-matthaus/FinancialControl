using Financial.Control.Application.Models.Revenues;
using Financial.Control.Application.Models.Revenues.Queries;
using Financial.Control.Application.Models.Revenues.Response.List;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Revenues
{
    internal class RevenueListHandler : BaseRequestHandler<RevenueListRequest, RevenueListResponse>
    {
        public RevenueListHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<RevenueListResponse> Handle(RevenueListRequest request, CancellationToken cancellationToken)
        {
            DateTime dateFilter;
            DateTime.TryParse($"{request.Month}/{request.Year}", out dateFilter);

            IReadOnlyCollection<Revenue> revenues = await _app.UnitOfWork.Revenues
                .Query(rev => rev.User.Id.Equals(_app.CurrentUser.Id) &&
                      (dateFilter == default || rev.Date.Equals(dateFilter))
                ).ToListAsync(cancellationToken);

            return RevenueListResponse.AsSuccess(revenues.Any() ? RevenueMessage.RevenueListSuccess() : RevenueMessage.RevenueListNotFound(),
                HttpStatusCode.OK, RevenueListSuccessResponse.Create(revenues.ToList().ConvertAll(rev => RevenueModel.Create(rev)))); ;
        }
    }
}
