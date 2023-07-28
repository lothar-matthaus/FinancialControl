using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Update;

namespace Financial.Control.Application.Models.Revenues.Response.Update
{
    public class RevenueUpdateSuccessResponse : BaseSuccessResponse, IRevenueUpdateSuccessResponse
    {
        public IRevenueModel Result { get; }

        private RevenueUpdateSuccessResponse(Revenue revenue)
        {
            Result = RevenueModel.Create(revenue);
        }

        #region Factory
        public static RevenueUpdateSuccessResponse Create(Revenue revenue) => new RevenueUpdateSuccessResponse(revenue);
        #endregion
    }
}
