namespace Financial.Control.Domain.Models
{
    public interface ISuccessSingleResponse<TModel> : ISuccessResponse<TModel> where TModel : IBaseModel
    {
        public TModel Result { get; }
    }
}
