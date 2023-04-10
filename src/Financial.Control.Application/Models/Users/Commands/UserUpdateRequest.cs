using Financial.Control.Application.Models.Users.Response.Update;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserUpdateRequest : BaseRequest<UserUpdateResponse>
    {
        /// <summary>
        /// Nome do usuário a ser criado
        /// </summary>
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login.
        /// </summary>
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail inserido está no formato inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário.
        /// </summary>
        [Required(ErrorMessage = "O campo 'PictureProfileUrl' é obrigatório.")]
        public string ProfilePictureUrl { get; set; }
    }
}
