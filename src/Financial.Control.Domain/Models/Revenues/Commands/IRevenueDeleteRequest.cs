namespace Financial.Control.Domain.Models.Revenues.Commands
{
    public interface IRevenueDeleteRequest : IBaseRequest, IBaseIdRequest
    {
        public new long Id { get; }
    }
}
