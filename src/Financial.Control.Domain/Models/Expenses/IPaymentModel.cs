using Financial.Control.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
