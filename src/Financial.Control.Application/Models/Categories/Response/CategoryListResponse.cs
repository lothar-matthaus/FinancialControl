using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Categories.Response.List;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Categories.Response
{
    public sealed class CategoryListResponse : BaseResponse<ICategoryListSuccessResponse, ICategoryListErrorResponse>, ICategoryListResponse
    {
        public CategoryListResponse() { }
        public CategoryListResponse(string message, HttpStatusCode statusCode, ICategoryListSuccessResponse success) : base(message, statusCode, success) { }
        public CategoryListResponse(string message, HttpStatusCode statusCode, ICategoryListErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static CategoryListResponse AsSuccess(string message, HttpStatusCode statusCode, ICategoryListSuccessResponse success) => new CategoryListResponse(message, statusCode, success);
        public static CategoryListResponse AsError(string message, HttpStatusCode statusCode, ICategoryListErrorResponse error) => new CategoryListResponse(message, statusCode, error);

        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CategoryMessage.CategoryListError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = CategoryListErrorResponse.Create(message, errors);
        }
    }
}
