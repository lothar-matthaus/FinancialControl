using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public class SuccessListResponse<TModel> : ISuccessListResponse<TModel> where TModel : IBaseModel
    {
        public IReadOnlyCollection<TModel> Result { get; }

        private SuccessListResponse(IReadOnlyCollection<TModel> list)
        {
            Result = list;
        }

        #region Factory
        public static SuccessListResponse<TModel> Create(IReadOnlyCollection<TModel> list) => new SuccessListResponse<TModel>(list);
        #endregion
    }
}
