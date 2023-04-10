using Financial.Control.Application.Models.Logon.Response;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Logon.Commands
{
    public class LoginRequest : BaseRequest<LoginResponse>
    {
        /// <summary>
        /// E-mail do usuário a logar.
        /// </summary>
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail inserido está no formato inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário a logar
        /// </summary>
        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        public string Password { get; set; }
    }
}
