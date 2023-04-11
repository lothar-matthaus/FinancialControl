using Financial.Control.Application.Models.Users.Response.Update;
using Financial.Control.Domain.Models.Users.Commands;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserUpdateRequest : BaseRequest<UserUpdateResponse>, IUserUpdateRequest
    {
        /// <summary>
        /// Nome do usuário a ser alterado
        /// </summary>
        [DisplayName("Nome")]
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login a ser alterada.
        /// </summary>
        [EmailAddress(ErrorMessage = "O E-mail inserido está no formato inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário a ser alterada.
        /// </summary>
        public string ProfilePictureUrl { get; set; }
    }
}
