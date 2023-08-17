namespace Financial.Control.Domain.Models
{
    public interface ISuccessListResponse<TModel> : ISuccessResponse<TModel> where TModel : IBaseModel
    {
        public IReadOnlyCollection<TModel> Result { get; }
    }
}
