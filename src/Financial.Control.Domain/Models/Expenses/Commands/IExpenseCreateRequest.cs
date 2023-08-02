using Financial.Control.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Expenses.Commands
{
    public interface IExpenseCreateRequest : IBaseRequest
    {
        public string Description { get; }
        public string CardNumber { get; }
        public decimal Value { get; }
        public PaymentType PaymentType { get; }
        public int Instalment { get; }
        public long CategoryId { get; }
    }
}
