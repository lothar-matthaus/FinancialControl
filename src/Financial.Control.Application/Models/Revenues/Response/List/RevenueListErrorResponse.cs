using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.List;

namespace Financial.Control.Application.Models.Revenues.Response.List
{
    internal class RevenueListErrorResponse : BaseErrorResponse, IRevenueListErrorResponse
    {
        private RevenueListErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static IRevenueListErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new RevenueListErrorResponse(message, errors);
        #endregion
    }
}
