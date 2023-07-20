namespace Financial.Control.Domain.Models.Revenues.Queries
{
    public interface IRevenueListRequest : IBaseRequest
    {
        public short Month { get; }
        public short Year { get; }
    }
}
