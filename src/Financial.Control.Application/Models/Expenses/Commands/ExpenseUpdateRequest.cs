﻿using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Domain.Models.Expenses.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Expenses.Commands
{
    public sealed class ExpenseUpdateRequest : BaseRequest<ExpenseUpdateResponse>, IExpenseUpdateRequest
    {
        public long Id { get; private set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public long CategoryId { get; set; }

        public void SetRequestId(long id)
        {
            Id = id;
        }
    }
}
