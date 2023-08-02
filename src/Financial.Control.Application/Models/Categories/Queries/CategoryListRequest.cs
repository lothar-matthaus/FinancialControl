using Financial.Control.Application.Models.Categories.Response;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Categories.Queries
{
    public class CategoryListRequest : BaseRequest<CategoryListResponse>, ICategoryListRequest
    {
        public string Name { get; set; }
    }
}
