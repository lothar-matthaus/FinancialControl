using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Expenses.Response;

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
