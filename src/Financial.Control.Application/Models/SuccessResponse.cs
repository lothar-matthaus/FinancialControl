using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Users;

namespace Financial.Control.Application.Models
{
    public class SuccessResponse<TModel> : ISuccessResponse<TModel> where TModel : IBaseModel
    {
        public TModel Result { get; }
        public IReadOnlyCollection<TModel> List { get; }

        private SuccessResponse(TModel model)
        {
            Result = model;
        }
        private SuccessResponse(IReadOnlyCollection<TModel> list)
        {
            List = list;
        }

        #region Factory
        public static SuccessResponse<TModel> Create(TModel model) => new SuccessResponse<TModel>(model);
        public static SuccessResponse<TModel> Create(IReadOnlyCollection<TModel> list) => new SuccessResponse<TModel>(list);

        internal ISuccessResponse<IUserModel> Create(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
