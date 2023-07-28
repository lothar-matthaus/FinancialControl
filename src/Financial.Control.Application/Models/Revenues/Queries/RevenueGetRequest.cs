using Financial.Control.Application.Models.Revenues.Response.Get;
using Financial.Control.Domain.Exceptions;
using Financial.Control.Domain.Models.Revenues.Queries;

namespace Financial.Control.Application.Models.Revenues.Queries
{
    public sealed class RevenueGetRequest : BaseRequest<RevenueGetResponse>, IRevenueGetRequest
    {
        public long Id { get; }

        public RevenueGetRequest(long id)
        {
            if (id == default)
                throw new InvalidInputException("O campo 'Id' precisa ter um valor válido.");

            Id = id;
        }
    }
}
