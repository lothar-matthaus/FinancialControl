using Financial.Control.Domain.Entities;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        public UserToken GenerateAccessToken(User user);
        public UserToken Login(User user, string plainTextPassword, CancellationToken cancellationToken);
    }
}
