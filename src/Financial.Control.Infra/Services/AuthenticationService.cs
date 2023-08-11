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
        private readonly IAppConfig _appConfig;
        private readonly INotificationManager _notificationManager;

        public AuthenticationService(IAppConfig appConfig, INotificationManager notificationManager)
        {
            _appConfig = appConfig;
            _notificationManager = notificationManager;
        }
        public UserToken GenerateAccessToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_appConfig.JwtConfig.Secret);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Account.Email.Value.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appConfig.JwtConfig.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appConfig.JwtConfig.Issuer,
                IssuedAt = DateTime.UtcNow
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return UserToken.Create(tokenString, tokenDescriptor.Expires.Value);
        }

        public UserToken Login(User user, string plainTextPassword, CancellationToken cancellationToken)
        {
            Password loginPassword = Password.CreateWithSalt(plainTextPassword, new StringBuilder(user?.Account?.Password?.Salt));

            if (!loginPassword.Value.Equals(user?.Account?.Password?.Value))
                return null;

            UserToken token = GenerateAccessToken(user);

            user.Account?.SetToken(token);

            return user.Account.Token;
        }
    }
}
