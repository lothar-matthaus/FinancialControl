using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Create;

namespace Financial.Control.Application.Models.Revenues.Response.Create
{
    public sealed class RevenueCreateSuccessResponse : BaseSuccessResponse, IRevenueCreateSuccessResponse
    {
        public IRevenueModel Result { get; }
        private RevenueCreateSuccessResponse(Revenue revenue) => Result = RevenueModel.Create(revenue);

        #region Factory
        public static RevenueCreateSuccessResponse Create(Revenue revenue) => new RevenueCreateSuccessResponse(revenue);
        #endregion
    }
}
