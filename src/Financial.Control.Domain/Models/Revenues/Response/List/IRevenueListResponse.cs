namespace Financial.Control.Domain.Models.Revenues.Response.List
{
    public interface IRevenueListResponse : IBaseResponse<ISuccessListResponse<IRevenueModel>, IErrorResponse, IRevenueModel>, IBaseResponse
    {
    }
}
