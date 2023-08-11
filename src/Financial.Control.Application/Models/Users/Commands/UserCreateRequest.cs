using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Models.Users.Commands;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserCreateRequest : BaseRequest<UserCreateResponse>, IUserCreateRequest
    {
        /// <summary>
        /// Nome do usuário a ser criado
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha do usuário
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário.
        /// </summary>
        public string ProfilePictureUrl { get; set; }
    }
}
