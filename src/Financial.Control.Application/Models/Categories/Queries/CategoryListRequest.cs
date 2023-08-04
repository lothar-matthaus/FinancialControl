using Financial.Control.Application.Models.Categories.Response;
using Financial.Control.Domain.Models.Categories.Queries;

namespace Financial.Control.Application.Models.Categories.Queries
{
    public class CategoryListRequest : BaseRequest<CategoryListResponse>, ICategoryListRequest
    {
        public string Name { get; set; }
    }
}
