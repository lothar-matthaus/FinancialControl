using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Application.Models.Expenses
{
    public class ExpenseModel : BaseModel, IExpenseModel
    {
        public string Description { get; }
        public bool PaidOut { get; }
        public Payment Payment { get; }

        private ExpenseModel(Expense expense) : base(expense.Id, expense.CreationDate, expense.UpdateDate)
        {
            Description = expense.Description;
            Payment = expense.Payment;
            PaidOut = expense.PaidOut;
        }

        #region Factory
        public static IExpenseModel Create(Expense expense) => new ExpenseModel(expense);
        #endregion
    }
}
