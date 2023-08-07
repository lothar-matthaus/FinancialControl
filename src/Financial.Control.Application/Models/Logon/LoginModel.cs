using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Logon;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Application.Models.Logon
{
    public class LoginModel : ILoginModel
    {
        public string Name { get; }
        public string Email { get; }
        public UserToken Token { get; }

        private LoginModel(User user)
        {
            Name = user.Name;
            Email = user.Account.Email.Value;
            Token = user.Account.Token;
        }

        public static LoginModel Create(User user) => new LoginModel(user);
    }
}
