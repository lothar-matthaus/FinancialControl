using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Create;

namespace Financial.Control.Application.Models.Revenues.Response.Create
{
    public sealed class RevenueCreateErrorResponse : BaseErrorResponse, IRevenueCreateErrorResponse
    {
        private RevenueCreateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }
       
        #region Factory
        public static RevenueCreateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new RevenueCreateErrorResponse(message, errors);
        #endregion
    }
}
