namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueDeleteRequest : IBaseRequest
    {
        public string RevenueId { get; }
    }
}
