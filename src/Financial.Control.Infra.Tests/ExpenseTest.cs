using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Enums;
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
            Card card = DebitCard.Create("Cartão de débito", "5279 4933 5966 5981");
            Payment payment = Payment.Create(200, 1, PaymentType.CreditCard);

            Expense expense = Expense.Create("Ração para os gatos", category, card, payment);

            Assert.True(expense.IsValid());
        }
    }
}
