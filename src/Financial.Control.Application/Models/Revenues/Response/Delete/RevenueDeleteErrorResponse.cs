using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Delete;

namespace Financial.Control.Application.Models.Revenues.Response.Delete
{
    public class RevenueDeleteErrorResponse : BaseErrorResponse, IRevenueDeleteErrorResponse
    {
        private RevenueDeleteErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static RevenueDeleteErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new RevenueDeleteErrorResponse(message, errors);
        #endregion
    }
}
