namespace Financial.Control.Domain.Models.Revenues.Response.Update
{
    public interface IRevenueUpdateSuccessResponse : IBaseSuccessResponse
    {
        public IRevenueModel Result { get; }
    }
}
