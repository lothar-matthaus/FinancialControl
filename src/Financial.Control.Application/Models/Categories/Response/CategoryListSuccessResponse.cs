using Financial.Control.Domain.Models.Categories;
using Financial.Control.Domain.Models.Categories.Response.List;

namespace Financial.Control.Application.Models.Categories.Response
{
    public sealed class CategoryListSuccessResponse : BaseSuccessResponse, ICategoryListSuccessResponse
    {
        public IReadOnlyCollection<ICategoryModel> Result { get; }

        private CategoryListSuccessResponse(IReadOnlyCollection<ICategoryModel> categories) => Result = categories;

        #region Factory
        public static CategoryListSuccessResponse Create(IReadOnlyCollection<ICategoryModel> categories) => new CategoryListSuccessResponse(categories);
        #endregion
    }
}
