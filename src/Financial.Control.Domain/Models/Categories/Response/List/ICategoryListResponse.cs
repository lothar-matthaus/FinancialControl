using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Categories.Response.List
{
    public interface ICategoryListResponse : IBaseResponse<ICategoryListSuccessResponse, ICategoryListErrorResponse>, IBaseResponse
    {
    }
}
