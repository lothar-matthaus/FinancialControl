using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Domain.Models.Logon
{
    public interface ILoginModel : IBaseModel
    {
        public string Name { get; }
        public string Email { get; }
        public UserToken Token { get; }
    }
}
