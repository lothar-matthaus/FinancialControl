using Financial.Control.Application.Models.Users.Response.Update.Password;
using Financial.Control.Application.Validation.Users;
using Financial.Control.Domain.Models.Users.Commands;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public sealed class UserUpdatePasswordRequest : BaseRequest<UserUpdatePasswordResponse>, IUserUpdatePasswordRequest
    {
        [PasswordValidation]
        [Required(ErrorMessage = "O campo 'Senha atual' é obrigatório ")]
        public string CurrentPassword { get; set; }

        [PasswordValidation]
        [Required(ErrorMessage = "O campo 'nova senha' é obrigatório ")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "O campo 'confirmar nova senha' é obrigatório ")]
        [PasswordValidation]
        [Compare(nameof(NewPassword), ErrorMessage = "A nova senha e confirmar nova senha não correspondem.")]
        public string ConfirmNewPassword { get; set; }
    }
}
