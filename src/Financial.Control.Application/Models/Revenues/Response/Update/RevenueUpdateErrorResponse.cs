using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Update;

namespace Financial.Control.Application.Models.Revenues.Response.Update
{
    public class RevenueUpdateErrorResponse : BaseErrorResponse, IRevenueUpdateErrorResponse
    {
        private RevenueUpdateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static RevenueUpdateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new RevenueUpdateErrorResponse(message, errors);
        #endregion
    }
}
