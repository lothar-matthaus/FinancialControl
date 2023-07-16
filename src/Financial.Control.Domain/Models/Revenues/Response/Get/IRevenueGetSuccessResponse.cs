namespace Financial.Control.Domain.Models.Revenues.Response.Get
{
    public interface IRevenueGetSuccessResponse : IBaseSuccessResponse
    {
        public IRevenueModel Result { get; }
    }
}
