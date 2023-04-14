namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueCreateRequest : IBaseRequest
    {
        public string Name { get; }
        public decimal Value { get; }
    }
}
