using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Revenues.Response.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Revenues.Response.List
{
    internal class RevenueListErrorResponse : BaseErrorResponse, IRevenueListErrorResponse
    {
        private RevenueListErrorResponse(string message, IReadOnlyCollection<Notification> errors) :base(message, errors) { }

        #region Factory
        public static IRevenueListErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new RevenueListErrorResponse(message, errors);
        #endregion
    }
}
