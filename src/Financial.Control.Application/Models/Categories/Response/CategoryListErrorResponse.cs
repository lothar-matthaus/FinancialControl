using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Categories.Response.List;

namespace Financial.Control.Application.Models.Categories.Response
{
    public class CategoryListErrorResponse : BaseErrorResponse, ICategoryListErrorResponse
    {
        private CategoryListErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static CategoryListErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CategoryListErrorResponse(message, errors);
        #endregion
    }
}
