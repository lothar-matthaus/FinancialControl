namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueUpdateRequest : IBaseRequest, IUpdateRequest
    {
        public new long Id { get; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
