using Financial.Control.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Expenses
{
    public interface IExpenseModel : IBaseModel
    {
        public string Description { get; }
        public bool PaidOut { get; }
        public Payment Payment { get; }
    }
}
