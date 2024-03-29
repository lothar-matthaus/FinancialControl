﻿using Financial.Control.Domain.Models.Categories;

namespace Financial.Control.Domain.Models.Expenses
{
    public interface IExpenseModel : IBaseModel
    {
        public new long Id { get; }
        public string Description { get; }
        public bool PaidOut { get; }
        public IPaymentModel Payment { get; }
        public ICategoryModel Category { get; }
    }
}
