namespace Financial.Control.Domain.Models
{
    public interface ISuccessResponse<TModel> where TModel : IBaseModel
    {
        public TModel Result { get; }
        public IReadOnlyCollection<TModel> List { get; }
    }
}
