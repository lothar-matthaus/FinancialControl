namespace Financial.Control.Domain.Models.Users.Response.Create
{
    public interface IUserCreateResponse : IBaseResponse<ISuccessSingleResponse<IUserModel>, IErrorResponse, IUserModel>, IBaseResponse
    {
    }
}
