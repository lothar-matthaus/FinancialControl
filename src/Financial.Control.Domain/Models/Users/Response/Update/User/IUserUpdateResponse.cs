namespace Financial.Control.Domain.Models.Users.Response.Update.User
{
    public interface IUserUpdateResponse : IBaseResponse<ISuccessSingleResponse<IUserModel>, IErrorResponse, IUserModel>, IBaseResponse
    {
    }
}
