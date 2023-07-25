namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueUpdateRequest : IBaseRequest, IBaseIdRequest
    {
        public new long Id { get; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
