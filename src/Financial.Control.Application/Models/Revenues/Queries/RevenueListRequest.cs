using Financial.Control.Application.Models.Revenues.Response.List;
using Financial.Control.Domain.Models.Revenues.Queries;

namespace Financial.Control.Application.Models.Revenues.Queries
{
    public sealed class RevenueListRequest : BaseRequest<RevenueListResponse>, IRevenueListRequest
    {
        public short Month { get; set; }
        public short Year { get; set; }
    }
}
