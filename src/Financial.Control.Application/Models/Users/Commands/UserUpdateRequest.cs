using Financial.Control.Application.Models.Users.Response.Update.Users;
using Financial.Control.Domain.Models.Users.Commands;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserUpdateRequest : BaseRequest<UserUpdateResponse>, IUserUpdateRequest
    {
        /// <summary>
        /// Nome do usuário a ser alterado
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login a ser alterada.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário a ser alterada.
        /// </summary>
        public string ProfilePictureUrl { get; set; }
    }
}
