using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues;

namespace Financial.Control.Application.Models.Revenues
{
    public sealed class RevenueModel : BaseModel, IRevenueModel
    {
        public string Name { get; }
        public decimal Value { get; }
        public string Month { get; }

        private RevenueModel(Revenue revenue) : base(revenue.Id, revenue.CreationDate, revenue.UpdateDate)
        {
            Name = revenue.Name;
            Value = revenue.Value;
            Month = revenue.Date.ToString("MM/yyyy");
        }

        #region Factory
        public static RevenueModel Create(Revenue revenue) => new RevenueModel(revenue);
        #endregion
    }
}
