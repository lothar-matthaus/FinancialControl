using Financial.Control.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Domain.Models.Expenses.Commands
{
    public interface IExpenseCreateRequest : IBaseRequest
    {
        public string Description { get; }
        public string CardNumber { get; }
        public decimal Value { get; }
        public PaymentType PaymentType { get; }
        public int Installment { get; }
        public long CategoryId { get; }
    }
}
