using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Enums;

namespace Financial.Control.Application.Models.Expenses.Commands
{
    public class ExpenseCreateRequest : BaseRequest<ExpenseCreateResponse>
    {
        public string Description { get; set; }
        public string CardNumber { get; set; }
        public decimal Value { get; set; }
        public PaymentType PaymentType { get; set; }
        public int Installment { get; set; }
        public long CategoryId { get; set; }
    }
}
