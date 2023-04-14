using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues;

namespace Financial.Control.Application.Models.Revenues
{
    public sealed class RevenueModel : IRevenueModel
    {
        public long Id { get; }
        public string Name { get; }
        public decimal Value { get; }

        private RevenueModel(Revenue revenue)
        {
            Id = revenue.Id;
            Name = revenue.Name;
            Value = revenue.Value;
        }

        #region Factory
        public static RevenueModel Create(Revenue revenue) => new RevenueModel(revenue);
        #endregion
    }
}
