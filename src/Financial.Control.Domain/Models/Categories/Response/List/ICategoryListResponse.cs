namespace Financial.Control.Domain.Models.Categories.Response.List
{
    public interface ICategoryListResponse : IBaseResponse<ISuccessListResponse<ICategoryModel>, IErrorResponse, ICategoryModel>, IBaseResponse
    {
    }
}
