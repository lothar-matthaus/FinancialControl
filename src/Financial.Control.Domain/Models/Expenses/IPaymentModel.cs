using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Models.Expenses
{
    public interface IPaymentModel
    {
        public decimal Value { get; }
        public decimal TotalValue { get; }
        public KeyValuePair<PaymentType, string> PaymentType { get; }
        public int Installment { get; }
    }
}
