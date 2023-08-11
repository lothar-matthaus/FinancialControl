using Financial.Control.Application.Models.Logon.Response;
using Financial.Control.Domain.Models.Logon.Commands;

namespace Financial.Control.Application.Models.Logon.Commands
{
    public class LoginRequest : BaseRequest<LoginResponse>, ILoginRequest
    {
        /// <summary>
        /// E-mail do usuário a logar.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário a logar
        /// </summary>
        public string Password { get; set; }
    }
}
