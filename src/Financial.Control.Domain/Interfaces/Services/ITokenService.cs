using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Records;

namespace Financial.Control.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public UserToken GenerateAccessToken(User user);
    }
}
