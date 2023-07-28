using Financial.Control.Application.Models.Revenues.Response.Update;
using Financial.Control.Domain.Exceptions;
using Financial.Control.Domain.Models.Revenues.Commands;

namespace Financial.Control.Application.Models.Revenues.Commands
{
    public class RevenueUpdateRequest : BaseRequest<RevenueUpdateResponse>, IRevenueUpdateRequest
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public void SetRequestId(long id)
        {
            if (id == default)
                throw new InvalidInputException("O campo 'Id' precisa ter um valor válido.");

            Id = id;
        }
    }
}
