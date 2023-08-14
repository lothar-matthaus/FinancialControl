using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Models.Expenses.Queries;

namespace Financial.Control.Application.Models.Expenses.Queries
{
    public class ExpenseListRequest : BaseRequest<ExpenseListResponse>, IExpenseListRequest
    {
        private ExpenseListRequest() { }

        #region Factory
        public static ExpenseListRequest Create() => new ExpenseListRequest();
        #endregion
    }
}
