using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public class SuccessResponse<TModel> : ISuccessSingleResponse<TModel> where TModel : IBaseModel
    {
        public TModel Result { get; }

        private SuccessResponse(TModel model)
        {
            Result = model;
        }

        #region Factory
        public static SuccessResponse<TModel> Create(TModel model) => new SuccessResponse<TModel>(model);
        #endregion
    }
}
