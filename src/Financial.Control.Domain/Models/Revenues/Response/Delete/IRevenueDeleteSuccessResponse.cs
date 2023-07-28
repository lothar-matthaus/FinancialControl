namespace Financial.Control.Domain.Models.Revenues.Response.Delete
{
    public interface IRevenueDeleteSuccessResponse : IBaseSuccessResponse
    {
        public IRevenueModel Result { get; }
    }
}
