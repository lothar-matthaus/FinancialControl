using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public class SuccessSingleResponse<TModel> : ISuccessSingleResponse<TModel> where TModel : IBaseModel
    {
        public TModel Result { get; }

        private SuccessSingleResponse(TModel model)
        {
            Result = model;
        }

        #region Factory
        public static SuccessSingleResponse<TModel> Create(TModel model) => new SuccessSingleResponse<TModel>(model);
        #endregion
    }
}
