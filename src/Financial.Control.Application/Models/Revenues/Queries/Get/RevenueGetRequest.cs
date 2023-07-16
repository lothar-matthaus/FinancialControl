using Financial.Control.Application.Models.Revenues.Response.Get;
using Financial.Control.Domain.Models.Revenues.Queries;

namespace Financial.Control.Application.Models.Revenues.Queries.Get
{
    public sealed class RevenueGetRequest : BaseRequest<RevenueGetResponse>, IRevenueGetRequest
    {
        public long RevenueId { get; set; }
    }
}
