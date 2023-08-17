using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Models.Expenses.Queries;

namespace Financial.Control.Application.Models.Expenses.Queries
{
    public sealed class ExpenseGetRequest : BaseRequest<ExpenseGetResponse>, IExpenseGetRequest
    {
        public long Id { get; }

        public ExpenseGetRequest(long id)
        {
            Id = id;
        }
    }
}
