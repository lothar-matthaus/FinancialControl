using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Financial.Control.Infra.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppConfig _config;

        public AuthenticationService(IAppConfig config)
        {
            _config = config;
        }
        public UserToken GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.JwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Account.Email.Value.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_config.JwtConfig.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config.JwtConfig.Issuer,
                IssuedAt = DateTime.UtcNow
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return UserToken.Create(tokenString, tokenDescriptor.Expires.Value);
        }

        public UserToken Login(User user, string plainTextPassword, CancellationToken cancellationToken)
        {
            if (!user.Account.Password.IsMatchPassword(plainTextPassword))
                return null;

            UserToken token = GenerateAccessToken(user);

            user.Account?.SetToken(token);

            return user.Account.Token;
        }
    }
}
