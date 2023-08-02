using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Expenses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Expenses.Response
{
    public class ExpenseCreateErrorResponse : BaseErrorResponse, IExpenseCreateErrorResponse
    {
        private ExpenseCreateErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }

        #region Factory
        public static ExpenseCreateErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new ExpenseCreateErrorResponse(message, errors);
        #endregion
    }
}
