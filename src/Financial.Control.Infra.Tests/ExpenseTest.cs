using Financial.Control.Domain.Entities;
using Financial.Control.Domain.ValueObjects;
using Xunit;

namespace Financial.Control.Infra.Tests
{
    public class ExpenseTests
    {
        [Fact]
        public void ExpenseCreateTest()
        {
            Category category = Category.Create("Dinossauro");
            Card card = DebitCard.Create("Cartão de débito", "5213 7091 0049 8664");
            Payment payment = Payment.Create(200, 2, Domain.Enums.PaymentType.DebitCard);

            Expense expense = Expense.Create("Ração para os gatos", category, card, payment);

            Assert.True(expense.IsValid());
        }
    }
}
