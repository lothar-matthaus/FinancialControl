using Financial.Control.Domain.Entities;
using Xunit;

namespace Financial.Control.Infra.Tests
{
    public class ExpenseTests
    {
        [Fact]
        public void ExpenseCreateTest()
        {
            Category category = Category.Create("Dinossauro");
            Card card = DebitCard.Create("Cartão de débito", "5279 4933 5966 5981");

            Expense expense = Expense.Create("Ração para os gatos", category, card, 200, 2, Domain.Enums.PaymentType.DebitCard);

            Assert.True(expense.IsValid());
        }
    }
}
