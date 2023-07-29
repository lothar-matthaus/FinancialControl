using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Category.Response.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
