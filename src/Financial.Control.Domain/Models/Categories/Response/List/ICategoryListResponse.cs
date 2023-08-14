namespace Financial.Control.Domain.Models.Categories.Response.List
{
    public interface ICategoryListResponse : IBaseResponse<ISuccessResponse<ICategoryModel>, IErrorResponse, ICategoryModel>, IBaseResponse
    {
    }
}
