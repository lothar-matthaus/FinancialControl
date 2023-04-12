using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Application.Validation.Users;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Users.Commands;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserCreateRequest : BaseRequest<UserCreateResponse>, IUserCreateRequest
    {
        /// <summary>
        /// Nome do usuário a ser criado
        /// </summary>

        [Required(ErrorMessage = $"O campo 'Name' é obrigatório.")]
        [NameValidation(isRequired: true)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário que será utilizado no login.
        /// </summary>
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório.")]
        [EmailValidation]
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        [PasswordValidation]
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo 'ConfirmPassword' é obrigatório.")]
        [Compare(nameof(Password), ErrorMessage = "Os campos 'Password' e 'ConfirmPassword' não se correspondem.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Url da foto de perfil do usuário.
        /// </summary>
        [Required(ErrorMessage = "O campo 'PictureProfileUrl' é obrigatório.")]
        [UrlValidation]
        public string ProfilePictureUrl { get; set; }

        #region Implict Operator
        public static implicit operator User(UserCreateRequest request) => User.Create(request.Name, request.Email, request.ProfilePictureUrl, request.Password);
        #endregion
    }
}
