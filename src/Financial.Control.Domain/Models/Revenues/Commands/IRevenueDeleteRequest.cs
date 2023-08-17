namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueDeleteRequest : IBaseRequest, IUpdateRequest
    {
        public new long Id { get; }
    }
}
