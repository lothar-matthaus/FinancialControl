namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueUpdateRequest : IBaseRequest
    {
        public string RevenueId { get; }
        public string Name { get; }
        public decimal Value { get; }
    }
}
