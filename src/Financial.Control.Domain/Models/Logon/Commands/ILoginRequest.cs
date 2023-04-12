namespace Financial.Control.Domain.Models.Logon.Commands
{
    public interface ILoginRequest : IBaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
