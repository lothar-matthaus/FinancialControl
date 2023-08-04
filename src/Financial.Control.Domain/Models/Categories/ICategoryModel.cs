namespace Financial.Control.Domain.Models.Categories
{
    public interface ICategoryModel : IBaseModel
    {
        public new long Id { get; }
        public string Name { get; }
    }
}
