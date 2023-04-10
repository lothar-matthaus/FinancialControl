using Financial.Control.Application.Models.Users.Response.Create;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserCreateRequest : BaseRequest<UserCreateResponse>
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
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo 'Password' deve possuir no mínimo [8] caracteres.")]
        [PasswordPropertyText]
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo 'ConfirmPassword' é obrigatório.")]
        [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário.
        /// </summary>
        [Required(ErrorMessage = "O campo 'PictureProfileUrl' é obrigatório.")]
        public string ProfilePictureUrl { get; set; }
    }
}
