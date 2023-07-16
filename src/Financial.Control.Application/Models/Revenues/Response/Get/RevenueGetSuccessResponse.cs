using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Get;

namespace Financial.Control.Application.Models.Revenues.Response.Get
{
    internal class RevenueGetSuccessResponse : BaseSuccessResponse, IRevenueGetSuccessResponse
    {
        public IRevenueModel Result { get; }

        private RevenueGetSuccessResponse(Revenue revenue) => Result = RevenueModel.Create(revenue);

        #region Factory
        public static RevenueGetSuccessResponse Create(Revenue revenue) => new RevenueGetSuccessResponse(revenue); 
        #endregion
    }
}
