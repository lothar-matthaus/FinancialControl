using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Revenues.Response.Create;

namespace Financial.Control.Application.Models.Revenues.Response.Create
{
    public sealed class RevenueCreateErrorResponse : BaseErrorResponse, IRevenueCreateErrorResponse
    {
        private RevenueCreateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }
        #region Factory
        public static RevenueCreateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new RevenueCreateErrorResponse(errors);
        #endregion
    }
}
