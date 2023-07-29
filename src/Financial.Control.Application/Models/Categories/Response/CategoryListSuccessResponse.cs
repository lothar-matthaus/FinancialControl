using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Category;
using Financial.Control.Domain.Models.Category.Response.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
