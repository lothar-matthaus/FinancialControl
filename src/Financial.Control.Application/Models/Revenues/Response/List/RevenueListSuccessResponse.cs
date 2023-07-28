using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.List;

namespace Financial.Control.Application.Models.Revenues.Response.List
{
    internal class RevenueListSuccessResponse : BaseSuccessResponse, IRevenueListSuccessResponse
    {
        public IReadOnlyCollection<IRevenueModel> Result { get; }

        private RevenueListSuccessResponse(IReadOnlyCollection<IRevenueModel> list) => Result = list;

        #region Factory
        public static IRevenueListSuccessResponse Create(IReadOnlyCollection<IRevenueModel> list) => new RevenueListSuccessResponse(list);
        #endregion
    }
}
