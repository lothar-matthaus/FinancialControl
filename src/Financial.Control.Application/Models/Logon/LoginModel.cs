using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Records;

namespace Financial.Control.Application.Models.Logon
{
    public class LoginModel
    {
        public string Name { get; }
        public string Email { get; }
        public UserToken Token { get; }

        private LoginModel(User user)
        {
            Name = user.Name;
            Email = user.Email.Value;
            Token = user.Token;
        }

        public static LoginModel Create(User user) => new LoginModel(user);
    }
}
