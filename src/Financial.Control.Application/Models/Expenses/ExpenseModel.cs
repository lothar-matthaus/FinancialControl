using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Expenses;

namespace Financial.Control.Application.Models.Expenses
{
    public class ExpenseModel : BaseModel, IExpenseModel
    {
        public string Description { get; }
        public bool PaidOut { get; }
        public IPaymentModel Payment { get; }

        private ExpenseModel(Expense expense) : base(expense.Id, expense.CreationDate, expense.UpdateDate)
        {
            Description = expense.Description;
            PaidOut = expense.PaidOut;
            Payment = PaymentModel.Create(expense.Payment);
        }

        #region Factory
        public static IExpenseModel Create(Expense expense) => new ExpenseModel(expense);
        #endregion
    }
}
