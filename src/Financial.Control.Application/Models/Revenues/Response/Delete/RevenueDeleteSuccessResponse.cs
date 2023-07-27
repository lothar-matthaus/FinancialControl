using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues;
using Financial.Control.Domain.Models.Revenues.Response.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Revenues.Response.Delete
{
    public class RevenueDeleteSuccessResponse : BaseSuccessResponse, IRevenueDeleteSuccessResponse
    {
        public IRevenueModel Result { get; }

        private RevenueDeleteSuccessResponse(Revenue revenue) => Result = RevenueModel.Create(revenue);

        #region Factory
        public static RevenueDeleteSuccessResponse Create(Revenue revenue) => new RevenueDeleteSuccessResponse(revenue);
        #endregion
    }
}
