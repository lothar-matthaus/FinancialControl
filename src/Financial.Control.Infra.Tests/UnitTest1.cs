using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enum;
using Financial.Control.Domain.Records;

namespace Financial.Control.Infra.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            User user = User.Create("Lothar Matthaus Silva Uchôa", "lothar1258@hotmail.com", "google.com", "teste@123");
            Card card = CreditCard.Create("Visa", 2000M);
            user.AddCard(card);

            Category category = Category.Create("Reformas");
            Payment payment = Payment.Create(2300M, 10, PaymentType.CreditCard);

            Expense expense = Expense.Create("Materiais de construção", user, category, card, payment);
            user.AddExpense(expense);

            
        }
    }
}