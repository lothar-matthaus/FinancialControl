using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.Models.Expenses.Response;

namespace Financial.Control.Application.Models.Expenses.Response
{
    public class ExpenseCreateSuccessResponse : BaseSuccessResponse, IExpenseCreateSuccessResponse
    {
        public IExpenseModel Result { get; }

        private ExpenseCreateSuccessResponse(Expense expense) => Result = ExpenseModel.Create(expense);

        #region Factory
        public static ExpenseCreateSuccessResponse Create(Expense expense) => new ExpenseCreateSuccessResponse(expense);
        #endregion
    }
}
