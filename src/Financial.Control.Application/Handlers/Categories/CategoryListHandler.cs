using Financial.Control.Application.Models.Categories;
using Financial.Control.Application.Models.Categories.Queries;
using Financial.Control.Application.Models.Categories.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Categories
{
    public class CategoryListHandler : BaseRequestHandler<CategoryListRequest, CategoryListResponse>
    {
        public CategoryListHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<CategoryListResponse> Handle(CategoryListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Category> query = await _app.UnitOfWork.Categories
                .Query(cat => request.Name == null || EF.Functions.Like(cat.Name, $"{request.Name}%"))
                .ToListAsync(cancellationToken);

            IReadOnlyCollection<ICategoryModel> categories = query.Select(cat => CategoryModel.Create(cat))
                .ToList();

            return CategoryListResponse.AsSuccess(categories.Any() ? CategoryMessage.CategoryListsuccess() : CategoryMessage.CategoryListNotFound(),
                HttpStatusCode.OK, CategoryListSuccessResponse.Create(categories));
        }
    }
}
