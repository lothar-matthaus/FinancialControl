using Financial.Control.Application.Models.Users.Response.Update.Users;
using Financial.Control.Application.Validation.Users;
using Financial.Control.Domain.Models.Users.Commands;
using System.ComponentModel;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserUpdateRequest : BaseRequest<UserUpdateResponse>, IUserUpdateRequest
    {
        /// <summary>
        /// Nome do usuário a ser alterado
        /// </summary>
        [DisplayName("Nome")]
        [NameValidation]
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login a ser alterada.
        /// </summary>
        [EmailValidation]
        public string Email { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário a ser alterada.
        /// </summary>
        [UrlValidation]
        public string ProfilePictureUrl { get; set; }
    }
}
