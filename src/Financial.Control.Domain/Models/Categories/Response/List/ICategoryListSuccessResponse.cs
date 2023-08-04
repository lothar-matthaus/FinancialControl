namespace Financial.Control.Domain.Models.Categories.Response.List
{
    public interface ICategoryListSuccessResponse : IBaseSuccessResponse
    {
        public IReadOnlyCollection<ICategoryModel> Result { get; }
    }
}
