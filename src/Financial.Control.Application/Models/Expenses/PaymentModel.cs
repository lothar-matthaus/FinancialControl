using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Extensions;
using Financial.Control.Domain.Models.Expenses;
using Financial.Control.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Expenses
{
    public class PaymentModel : IPaymentModel
    {
        public decimal Value { get; }
        public decimal TotalValue { get; }
        public KeyValuePair<PaymentType, string> PaymentType { get; }
        public int Installment { get; }

        private PaymentModel(Payment payment)
        {
            Value = payment.Value;
            TotalValue = payment.GetTotalValue();
            PaymentType = new KeyValuePair<PaymentType, string>(payment.PaymentType, payment.PaymentType.GetDescription());
            Installment = payment.Installment;
        }

        #region Factory
        public static PaymentModel Create(Payment payment) => new PaymentModel(payment);
        #endregion
    }
}
