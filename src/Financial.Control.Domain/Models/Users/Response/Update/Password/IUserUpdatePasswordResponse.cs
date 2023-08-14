namespace Financial.Control.Domain.Models.Users.Response.Update.Password
{
    public interface IUserUpdatePasswordResponse : IBaseResponse<ISuccessResponse<IUserModel>, IErrorResponse, IUserModel>, IBaseResponse
    {
    }
}
