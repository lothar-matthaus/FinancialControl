using Financial.Control.Application.Models.Revenues.Response.Delete;
using Financial.Control.Domain.Exceptions;
using Financial.Control.Domain.Models.Revenues.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Revenues.Commands
{
    public class RevenueDeleteRequest : BaseRequest<RevenueDeleteResponse>
    {
        public long Id { get; }

        public RevenueDeleteRequest(long id)
        {
            if (id == default)
                throw new InvalidInputException("O campo 'Id' precisa ter um valor válido.");

            Id = id;
        }
    }
}
