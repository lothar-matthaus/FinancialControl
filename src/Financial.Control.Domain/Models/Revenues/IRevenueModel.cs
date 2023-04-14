namespace Financial.Control.Domain.Models.Revenues
{
    public interface IRevenueModel : IBaseModel
    {
        public new long Id { get; }
        public string Name { get; }
        public decimal Value { get; }
    }
}
