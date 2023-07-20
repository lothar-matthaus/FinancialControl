using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
