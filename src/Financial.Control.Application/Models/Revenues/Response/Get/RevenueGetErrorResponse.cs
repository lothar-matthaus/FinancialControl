using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.Get;

namespace Financial.Control.Application.Models.Revenues.Response.Get
{
    internal class RevenueGetErrorResponse : BaseErrorResponse, IRevenueGetErrorResponse
    {
        private RevenueGetErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static RevenueGetErrorResponse Create(string message, IReadOnlyCollection<Notification> errors = null) => new RevenueGetErrorResponse(message, errors);
        #endregion

    }
}
