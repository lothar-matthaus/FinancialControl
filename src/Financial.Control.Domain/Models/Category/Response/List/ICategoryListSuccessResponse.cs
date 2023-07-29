using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Category.Response.List
{
    public interface ICategoryListSuccessResponse : IBaseSuccessResponse
    {
        public IReadOnlyCollection<ICategoryModel> Result { get; }
    }
}
