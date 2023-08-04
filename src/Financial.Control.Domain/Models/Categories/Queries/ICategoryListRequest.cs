namespace Financial.Control.Domain.Models.Categories.Queries
{
    public interface ICategoryListRequest : IBaseRequest
    {
        public string Name { get; }
    }
}
