using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Revenues.Response.List
{
    public interface IRevenueListResponse : IBaseResponse<IRevenueListSuccessResponse, IRevenueListErrorResponse>, IBaseResponse
    {
    }
}
