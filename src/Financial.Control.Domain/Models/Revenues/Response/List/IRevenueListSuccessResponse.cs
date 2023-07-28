namespace Financial.Control.Domain.Models.Revenues.Response.List
{
    public interface IRevenueListSuccessResponse : IBaseSuccessResponse
    {
        public IReadOnlyCollection<IRevenueModel> Result { get; }
    }
}
