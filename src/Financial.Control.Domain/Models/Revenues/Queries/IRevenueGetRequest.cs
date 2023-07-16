namespace Financial.Control.Domain.Models.Revenues.Queries
{
    public interface IRevenueGetRequest : IBaseRequest
    {
        public long RevenueId { get; set; }
    }
}
