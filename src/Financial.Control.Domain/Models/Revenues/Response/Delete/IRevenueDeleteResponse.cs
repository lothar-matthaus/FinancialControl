using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Revenues.Response.Delete
{
    public interface IRevenueDeleteResponse : IBaseResponse<IRevenueDeleteSuccessResponse, IRevenueDeleteErrorResponse>, IBaseResponse
    {
    }
}
