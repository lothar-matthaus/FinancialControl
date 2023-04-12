namespace Financial.Control.Domain.Models.Logon.Response
{
    public interface ILoginSuccessResponse : IBaseSuccessResponse
    {
        public ILoginModel Result { get; }
    }
}
