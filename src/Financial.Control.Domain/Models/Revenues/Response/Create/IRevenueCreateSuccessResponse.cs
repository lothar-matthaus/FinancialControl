namespace Financial.Control.Domain.Models.Revenues.Response.Create
{
    public interface IRevenueCreateSuccessResponse : IBaseSuccessResponse
    {
        public IRevenueModel Result { get; }
    }
}
